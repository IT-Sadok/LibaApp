namespace DocsAndHospitals.UI
{

    public interface IOutput
    {
        void Write(string text);
        void WriteLine(string text);
        void Clear();
        void PressKey();
    }

}
