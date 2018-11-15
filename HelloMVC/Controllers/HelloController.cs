using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {

            string html = "<form method='post'>" +
                "<h4>Enter your name</h4>" +
                "<input type='text' name='name'>" +
                "<select name='lang' />" +
                "<option value=' '>" + "---Select a language---" + "</option>" +
                "<option value='en'>" + "English" + "</option>" +
                "<option value='fr'>" + "French" + "</option>" +
                "<option value='pr'>" + "Portuguese" + "</option>" +
                "<option value='jp'>" + "Japanese" + "</option>" +
                "<option value='ch'>" + "Chinese" + "</option>" +
                "</select>" +
                "<input type='submit' value='Get Greeting'>" +
                "</form>";

            //return Redirect("/Hello/Goodbye");
            return Content(html, "text/html");
        }

        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string lang, string name)
        {
            string greet = "Hello";

            switch (lang)
            {
                case "en":
                    greet = "Hello";
                    break;
                case "fr":
                    greet = "Bonjour";
                    break;
                case "pr":
                    greet = "Oi";
                    break;
                case "jp":
                    greet = "Konnichiwa";
                    break;
                case "ch":
                    greet = "Nihao";
                    break;
                default:
                    greet = "Hello";
                    break;
            }
           
            return Content(string.Format("<strong>{0}, {1}!</strong>", greet, name), "text/html");
        }

        //Handle requests to /Hello/NAME
        //Where NAME is the second part of the path (url segment)
        //[Route("/Hello/{name}")]
        //public IActionResult Index2(string name)
        //{
        //    return Content(string.Format("<strong>Hello, {0}!</strong>", name), "text/html");
        //}

        public IActionResult Goodbye()
        {
            return Content("Goodbye!");
        }

    }
}
