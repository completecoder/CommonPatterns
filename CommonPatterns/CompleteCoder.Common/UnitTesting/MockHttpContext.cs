using System.Web;

namespace CompleteCoder.Common.UnitTesting
{
    /// <summary>
    /// These Mocks are dependant on System.Web, so you need to add this to your Project's references
    /// </summary>
    public class MockResponse : HttpResponseBase
    {
        private readonly HttpCookieCollection cookies;
        public MockResponse(HttpCookieCollection cookies)
        {
            this.cookies = cookies;
        }

        public override HttpCookieCollection Cookies
        {
            get
            {
                return cookies;
            }
        }
    }
    public class MockRequest : HttpRequestBase
    {
        private readonly HttpCookieCollection cookies;


        public MockRequest(HttpCookieCollection cookies)
        {
            this.cookies = cookies;
        }

        public override HttpCookieCollection Cookies
        {
            get
            {
                return cookies;
            }
        }
    }
    public class MockHttpContext : HttpContextBase
    {
        private MockRequest request;
        private MockResponse response;
        private HttpCookieCollection cookies;
        private IPrincipal FakeUser;

        public override IPrincipal User
        {
            get
            {
                return this.FakeUser;
            }
            set
            {
                this.FakeUser = value;
            }
        }

        public MockHttpContext()
        {
            cookies = new HttpCookieCollection();
            this.request = new MockRequest(cookies);
            this.response = new MockResponse(cookies);
        }



        public override HttpRequestBase Request
        {
            get
            {
                return request;
            }
        }

        public override HttpResponseBase Response
        {
            get
            {
                return response;
            }
        }
    }
}
