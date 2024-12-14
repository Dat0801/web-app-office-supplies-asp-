using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public class CloudinaryUpload
    {
         private const string CloudName = "dvpzullxc"; // Thay bằng Cloud Name của bạn

    public async Task<string> UploadToCloudinaryAsync(string filePath, string folder)
    {
        // URL API Cloudinary để upload
        string url = $"https://api.cloudinary.com/v1_1/{CloudName}/image/upload";

        using (var client = new HttpClient())
        {
            try
            {
                // Tạo content cho request (multipart/form-data)
                using (var form = new MultipartFormDataContent())
                {
                    // Thêm file vào request body
                    var fileBytes = File.ReadAllBytes(filePath);  // Đọc nội dung file
                    var fileContent = new ByteArrayContent(fileBytes);
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg"); // Cập nhật MIME type nếu cần

                    form.Add(fileContent, "file", Path.GetFileName(filePath)); // "file" là tên tham số trên Cloudinary API

                    // Thêm upload preset (folder là upload preset của bạn)
                    form.Add(new StringContent(folder), "upload_preset");

                    // Gửi request POST tới Cloudinary
                    HttpResponseMessage response = await client.PostAsync(url, form);

                    // Kiểm tra xem yêu cầu có thành công không
                    if (!response.IsSuccessStatusCode)
                    {
                        string statusCode = response.StatusCode.ToString();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Network response was not ok. StatusCode: {statusCode}. Response: {responseBody}");
                    }

                    // Đọc kết quả JSON trả về từ Cloudinary
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<dynamic>(responseBody);

                    // Kiểm tra kết quả trả về có chứa URL hay không
                    if (result.secure_url != null)
                    {
                        return result.secure_url.ToString(); // Trả về URL hình ảnh đã upload
                    }
                    else
                    {
                        throw new Exception("Image upload failed");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading to Cloudinary: {ex.Message}");
                throw;
            }
        }
    }
    }
}
