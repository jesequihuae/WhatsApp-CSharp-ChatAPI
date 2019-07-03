using System;
using System.Collections.Generic;

namespace WhatsAppService

    /********************************************************************
      THIS CLASS IS AN API FOR C# TO USE CHAT-API IN THE WHATS APP BOT, 
      YOU CAN ADD METHODS, VARIABLES AND ALL YOU NEED FOR THE RIGHT USE
      CONTINUING WITH CONVENTIONS.

      DATE CREATED -> JULY 7TH, 2019
      CREATED BY   -> JESUS EQUIHUA EQUIHUA
    ********************************************************************/
{
    class APIWhatsApp
    {
        /*******************
         **** VARIABLES ****
         *******************/

        /* API VARIABLES */
        const String URL = "https://api.chat-api.com/";
        const String INSTANCE = "INSTANCENUMBER";
        const String TOKEN = "TOKENNUMBER";

        /* METHOD VARIABLES */
        const String SEND_MESSAGE = "sendMessage";
        const String LIST_MESSAGES = "messages";
      
        /// <summary>
        /// Generate URL base with URL and instance (e.g. https://api.chat-api.com/instance13637/)
        /// </summary>
        /// <returns></returns>
        private string generateURLBase()
        {
            return string.Concat(URL, INSTANCE, "/");
        }
        
        /// <summary>
        ///  Append token to URL string
        /// </summary>
        /// <returns></returns>
        private string appendToken()
        {
            return string.Concat("?token=", TOKEN);
        }

        /// <summary>
        /// Generate the URL necessary to send a message
        /// </summary>
        /// <returns>
        /// returns a valid URL string 
        /// </returns>
        public string sendMessageURL()
        {
            return string.Concat(generateURLBase(), SEND_MESSAGE, appendToken());
        }
        
        /// <summary>
        /// Generate the URL necessary to list messages - CHAT-API returns 100 registers only.
        /// </summary>
        /// <returns></returns>
        public string listMessagesURL()
        {
            return string.Concat(generateURLBase(), LIST_MESSAGES, "/", appendToken());
        }
        
        /// <summary>
        /// Generate the URL necessary to list messages from the message number
        /// </summary>
        /// <param name="LastNumber">From this number</param>
        /// <returns></returns>
        public string listMessagesByLastNumberURL(int LastNumber) 
        {
            return string.Concat(generateURLBase(), LIST_MESSAGES, "/", appendToken(), "&lastMessageNumber=", LastNumber);
        }
        
        /// <summary>
        /// Generate the URL necessary to list messages from message number and chat ID
        /// </summary>
        /// <param name="lastNumber">From this number</param>
        /// <param name="chatID">By this chat ID</param>
        /// <returns></returns>
        public string listMessageWithLastNumberByChatID(int lastNumber, string chatID)
        {
            return string.Concat(generateURLBase(), LIST_MESSAGES, "/", appendToken(), "&lastMessageNumber=", lastNumber, "&chatId=", chatID);
        }

    }

    /* CLASS FOR BODY TO THE SEND MESSAGE REQUEST */
    /// <summary>
    /// Body for sending messages.
    /// </summary>
    class RequestBodySendMessage
    {
        /* REQUIRED JSON VARIABLES */
        String phoneNumber { get; set; }
        String Message { get; set; }
        const String COUNTRY_AREA = "52";

        /// <summary>
        ///  Empty constructor
        /// </summary>
        public RequestBodySendMessage() { }
        
        /// <summary>
        /// Build the right body for sending messages.
        /// </summary>
        /// <param name="phoneNumber">Phone number who receive messages.</param>
        /// <param name="Message">Message you want to send.</param>
        public RequestBodySendMessage(string phoneNumber, string Message)
        {
            this.phoneNumber = formatNumber(phoneNumber);
            this.Message = Message;
        }

        /// <summary>
        ///     Returns a JSON in Dictionary format .
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> getJSON()
        {
            var Body = new Dictionary<string, string> {
              { "phone", phoneNumber },
              { "body", Message }
            };

            return Body;
        }

        /// <summary>
        ///    Returns phone number.
        /// </summary>
        /// <returns></returns>
        public String getPhoneNumber()
        {
            return this.phoneNumber;
        }

        /// <summary>
        ///  Set phone number.
        /// </summary>
        /// <param name="phoneNumber">Phone number</param>
        public void setPhoneNumber(string phoneNumber)
        {          
            this.phoneNumber =  formatNumber(phoneNumber);
        }

        /// <summary>
        ///  Returns the message
        /// </summary>
        /// <returns></returns>
        public String getMessage()
        {
            return this.Message;
        }

        /// <summary>
        ///  Set message.
        /// </summary>
        /// <param name="Message">Message you want to send.</param>
        public void setMessage(string Message)
        {
            this.Message = Message;
        }

        /// <summary>
        ///     Format phone number if it is missing the country area.
        /// </summary>
        /// <param name="phoneNumber">Phone number to format.</param>
        /// <returns></returns>
        private String formatNumber(string phoneNumber)
        {
            if (phoneNumber.Length == 10)
            {
                phoneNumber = string.Concat(COUNTRY_AREA, phoneNumber);
            }
            return phoneNumber;
        }
    }

}
