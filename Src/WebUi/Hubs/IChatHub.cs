using System;
using System.Threading.Tasks;

namespace WebUi.Hubs
{
    public interface IChatHub
    {
        Task MessageReceived(string user, string message, DateTime time);
    }
} 