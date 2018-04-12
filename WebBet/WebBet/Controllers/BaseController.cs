using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBet.Datas;

namespace WebBet.Controllers
{
    public abstract class BaseController : Controller
    {

        protected void DisplayMessage(string message, MessageType messageType)
        {
            TempData["Display"] = MessageToDisplay.Serialize(new MessageToDisplay { Message = message, MessageType = messageType });
        }

        public enum MessageType : int
        {
            OK = 1,
            ERROR = 2
        }

        /// <summary>
        /// Attention dans la view le cast en dynamic ne fonctionne pas
        /// </summary>
        public class MessageToDisplay
        {
            public string Message { get; set; }
            public MessageType MessageType { get; set; }

            public static string Serialize(MessageToDisplay messageToDisplay)
            {
                return messageToDisplay == null ? null : JsonConvert.SerializeObject(messageToDisplay);
            }

            public static MessageToDisplay Deserialize(string jsonFlux)
            {
                return string.IsNullOrWhiteSpace(jsonFlux)?null: JsonConvert.DeserializeObject<MessageToDisplay>(jsonFlux);
            }
        }
    }
}
