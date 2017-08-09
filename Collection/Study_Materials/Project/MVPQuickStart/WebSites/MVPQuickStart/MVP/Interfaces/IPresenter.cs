
namespace Dashboard.Interfaces
{
    public interface IPresenter
    {
        void RecieveNotice(IMessage message);
        void UpdateDisplay();
    }
}
