using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using T1808AHelloUWP.Entity;
using T1808AHelloUWP.Service;
using T1808AHelloUWP.Pages;

namespace T1808AHelloUWP.Service
{
    class SongService: ISongService
    {

        public Song CreateSong(MemberCredential memberCredential, Song song)
        {
            // tạo đối tượng httpclient giúp gửi dữ liệu đi. (hoặc lấy dữ liệu về)
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(memberCredential.token);
            // chuyển kiểu dữ liệu c# thành kiểu dữ liệu json.
            var dataToSend = JsonConvert.SerializeObject(song);
            // gói gém, gắn mác cho dữ liệu gửi đi, xác định kiểu dữ liệu là json, encode là utf8.
            var content = new StringContent(dataToSend, Encoding.UTF8, "application/json");
            // thực hiện gửi dữ liệu với phương thức post.
            var response = httpClient.PostAsync(ProjectConfiguration.SONG_CREATE_URL, content).GetAwaiter().GetResult();
            // lấy kết quả trả về từ server.
            var jsonContent = response.Content.ReadAsStringAsync().Result;
            // ép kiểu kết quả từ dữ liệu json sang dữ liệu của C#
            var responseSong = JsonConvert.DeserializeObject<Song>(jsonContent);
            // in ra id của member trả về.
            Debug.WriteLine("Create success with name: " + responseSong.name);
            return responseSong;
        }

      

        public List<Song> GetAllSong(MemberCredential memberCredential)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(memberCredential.token);
            var response = httpClient.GetAsync(ProjectConfiguration.SONG_GET_ALL).GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<List<Song>>(response.Content.ReadAsStringAsync().Result);
        }

        public List<Song> GetMineSongs(MemberCredential memberCredential)
        {
            throw new NotImplementedException();
        }
    }
}
