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
            string arrange = File.ReadAllText("Templates/HomePaje.html").Replace("\n", "").Replace(" ", "");
            var act = _httpClient.GetAsync("http://localhost:5000/").Result
                .Content.ReadAsStringAsync().Result
                .Replace("\n", "").Replace(" ", "");
           
            Assert.Equal(arrange, act);
        }

        [Theory]
        [InlineData("DDD@ddd", "123")]
        [InlineData("dddd@ddd", "123")]
        [InlineData("111@111", "wer")]
        public void LoginPageTest_ShouldRedirectProfilePage(string email, string password)
        {
            string arrange = File.ReadAllText("Templates/login.html").Replace("\n", "").Replace(" ", "");
            var content = new MultipartContent();
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                ["email"] = email,
                ["password"] = password
            };
            HttpContent contentForm = new FormUrlEncodedContent(data);
            var act = _httpClient.GetAsync("http://localhost:5000/login").Result
                .Content.ReadAsStringAsync()
                .Result.Replace("\n", "").Replace(" ", "");
            Assert.Equal(arrange, act);
        }
        [Theory]
        [InlineData("Www@ee", "666", "ggg")]
        [InlineData(" bbbb@bbbb ", "", "")]
        [InlineData("uuuu", "", "123")]
        [InlineData("www@qqquuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu", "hh", "222")]
        [InlineData("WWww@ww", "", "123")]
        public void SignUpTest_ShouldRedirectLoginPage(string email, string name, string password)
        {
            string arrange = File.ReadAllText("Templates/SingUp.html").Replace("\n", "").Replace(" ", "");
            var content = new MultipartContent();
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                ["email"] = email,
                ["name"] = name,
                ["password"] = password
            };
            HttpContent contentForm = new FormUrlEncodedContent(data);
            var act = _httpClient.PostAsync("http://localhost:5000/signup", contentForm).Result
                .Content.ReadAsStringAsync()
                .Result.Replace("\n", "").Replace(" ", "");
            Assert.Equal(arrange, act);
        }
        [Fact]
        public void LogoutPageTest_ShouldRedirectHomePage()
        {
            string arrange = File.ReadAllText("Templates/Logout.html").Replace("\n", "").Replace(" ", "");
            var act = _httpClient.GetAsync("http://localhost:5000/logout").Result
                .Content.ReadAsStringAsync()
                .Result.Replace("\n", "").Replace(" ", ""); 
            Assert.Equal(arrange, act);
        }
        [Fact]
        public void TestLoginWrongPassword_ShouldReturnExeption()
        {
            string arrange = File.ReadAllText("Templates/WrogPassword.html").Replace("\n", "").Replace(" ", "");
            var content = new MultipartContent();
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                ["email"] = "rrr@rrj",
                ["password"] = "123"
            };
            // создаем объект HttpContent
            HttpContent contentForm = new FormUrlEncodedContent(data);
            var act = _httpClient.PostAsync("http://localhost:5000/login", contentForm).Result.Content.ReadAsStringAsync().Result.Replace("\n", "").Replace(" ", "");
            Assert.Equal(arrange, act);
        }
        [Fact]
        public void TestLoginWrongEmail_ShouldReturnExeption()
        {
            string arrange = File.ReadAllText("Templates/WrongEmail.html").Replace("\n", "").Replace(" ", "");
            var content = new MultipartContent();
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                ["email"] = "rrr@rrjr",
                ["password"] = "kkk"
            };
            HttpContent contentForm = new FormUrlEncodedContent(data);
            var act = _httpClient.PostAsync("http://localhost:5000/login", contentForm).Result
                .Content.ReadAsStringAsync()
                .Result.Replace("\n", "").Replace(" ", "");
            Assert.Equal(arrange, act);

        }

        [Theory]
        [InlineData("", "yyy", "ggg")]
        [InlineData("", "hhh", "")]
        [InlineData("", "", "")]
        [InlineData("", "", "123")]
        [InlineData("", "", "")]
        public void SignUpError_ShouldReturnExeption(string email, string name, string password)
        {
            string arrange = File.ReadAllText("Templates/SignUpError.html").Replace("\n", "").Replace(" ", "");
            var content = new MultipartContent();
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                ["email"] = email,
                ["name"] = name,
                ["password"] = password
            };
            // создаем объект HttpContent
            HttpContent contentForm = new FormUrlEncodedContent(data);
            var act = _httpClient.PostAsync("http://localhost:5000/signup", contentForm).Result
                .Content.ReadAsStringAsync()
                .Result.Replace("\n", "").Replace(" ", "");
            Assert.Equal(arrange, act);
        }
        [Fact]
        public void ProfilePageTest_SouldReturnPageProfil()
        {
            string arrange = File.ReadAllText("Templates/Profil.html").Replace("\n", "").Replace(" ", "");
            var act = _httpClient.GetAsync("http://localhost:5000/profile").Result.Content.ReadAsStringAsync().Result.Replace("\n", "").Replace(" ", "");
            Assert.Equal(arrange, act);

        }
    }
}