namespace TestProject1
{
    public class ApiTests
    {
        private HttpClient _httpClient;

        public ApiTests()
        {
            _httpClient = new HttpClient();
        }

        [Fact]
        public void HomePageTest_ShouldRedirectTheHomePage()
        {
            string html = File.ReadAllText("Templates/HomePaje.html").Replace("\n", "").Replace(" ", "");
            var c = _httpClient.GetAsync("http://localhost:5000/").Result;
            var v = c.Content.ReadAsStringAsync().Result.Replace("\n", "").Replace(" ", ""); 
            Assert.Equal(html, v);
        }

        [Theory]
        [InlineData("DDD@ddd", "123")]
        [InlineData("dddd@ddd", "123")]
        [InlineData("111@111", "wer")]
        public void LoginPageTest_ShouldRedirectProfilePage(string email, string password)
        {
            string html = File.ReadAllText("Templates/login.html").Replace("\n", "").Replace(" ", "");
            var b = new MultipartContent();
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                ["email"] = email,
                ["password"] = password
            };
            HttpContent contentForm = new FormUrlEncodedContent(data);
            var c = _httpClient.GetAsync("http://localhost:5000/login").Result;
            var v = c.Content.ReadAsStringAsync().Result.Replace("\n", "").Replace(" ", "");
            Assert.Equal(html, v);
        }
        [Theory]
        [InlineData("Www@ee", "666", "ggg")]
        [InlineData(" bbbb@bbbb ", "", "")]
        [InlineData("uuuu", "", "123")]
        [InlineData("www@qqquuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu", "hh", "222")]
        [InlineData("WWww@ww", "", "123")]
        public void SignUpTest_ShouldRedirectLoginPage(string email, string name, string password)
        {
            string html = File.ReadAllText("Templates/SingUp.html").Replace("\n", "").Replace(" ", "");
            var b = new MultipartContent();
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                ["email"] = email,
                ["name"] = name,
                ["password"] = password
            };
            HttpContent contentForm = new FormUrlEncodedContent(data);
            var bn = _httpClient.PostAsync("http://localhost:5000/signup", contentForm).Result;
            var vc = bn.Content.ReadAsStringAsync().Result.Replace("\n", "").Replace(" ", "");
            Assert.Equal(html, vc);
        }
        [Fact]
        public void LogoutPageTest_ShouldRedirectHomePage()
        {
            string html = File.ReadAllText("Templates/Logout.html").Replace("\n", "").Replace(" ", "");
            var c = _httpClient.GetAsync("http://localhost:5000/logout").Result;
            var v = c.Content.ReadAsStringAsync().Result.Replace("\n", "").Replace(" ", "");
            Assert.Equal(html, v);
        }
        [Fact]
        public void TestLoginWrongPassword_ShouldReturnExeption()
        {
            string html = File.ReadAllText("Templates/WrogPassword.html").Replace("\n", "").Replace(" ", "");
            var b = new MultipartContent();
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                ["email"] = "rrr@rrj",
                ["password"] = "123"
            };
            // создаем объект HttpContent
            HttpContent contentForm = new FormUrlEncodedContent(data);
            var bn = _httpClient.PostAsync("http://localhost:5000/login", contentForm).Result;
            var vc = bn.Content.ReadAsStringAsync().Result.Replace("\n", "").Replace(" ", "");
            Assert.Equal(html, vc);

        }
        [Fact]
        public void TestLoginWrongEmail_ShouldReturnExeption()
        {
            string html = File.ReadAllText("Templates/WrongEmail.html").Replace("\n", "").Replace(" ", "");
            var b = new MultipartContent();
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                ["email"] = "rrr@rrjr",
                ["password"] = "kkk"
            };
            HttpContent contentForm = new FormUrlEncodedContent(data);
            var bn = _httpClient.PostAsync("http://localhost:5000/login", contentForm).Result;
            var vc = bn.Content.ReadAsStringAsync().Result.Replace("\n", "").Replace(" ", "");
            Assert.Equal(html, vc);

        }

        [Theory]
        [InlineData("", "yyy", "ggg")]
        [InlineData("", "hhh", "")]
        [InlineData("", "", "")]
        [InlineData("", "", "123")]
        [InlineData("", "", "")]
        public void SignUpError_ShouldReturnExeption(string email, string name, string password)
        {
            string html = File.ReadAllText("Templates/SignUpError.html").Replace("\n", "").Replace(" ", "");
            var b = new MultipartContent();
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                ["email"] = email,
                ["name"] = name,
                ["password"] = password
            };
            // создаем объект HttpContent
            HttpContent contentForm = new FormUrlEncodedContent(data);
            var bn = _httpClient.PostAsync("http://localhost:5000/signup", contentForm).Result;
            var vc = bn.Content.ReadAsStringAsync().Result.Replace("\n", "").Replace(" ", "");
            Assert.Equal(html, vc);
        }
        [Fact]
        public void ProfilePageTest_SouldReturnPageProfil()
        {
            string html = File.ReadAllText("Templates/Profil.html").Replace("\n", "").Replace(" ", "");
            var c = _httpClient.GetAsync("http://localhost:5000/profile").Result;
            var v = c.Content.ReadAsStringAsync().Result.Replace("\n", "").Replace(" ", "");
            Assert.Equal(html, v);

        }
    }
}