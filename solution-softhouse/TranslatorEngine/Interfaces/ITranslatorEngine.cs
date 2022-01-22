
namespace solution_softhouse.TranslatorEngine.Interfaces
{
    // made this into an interface in order to
    // have room for future translator implementations
    public interface ITranslatorEngine
    {
        string DoTranslation(string input);
    }
}
