using MVC.Models;

namespace MVC.Controllers
{
    public interface IFractionParser
    {
        Fraction Parse(string fileContent);
    }
}
