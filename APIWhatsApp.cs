using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace WhatsAppService

    /********************************************************************
      THIS CLASS IS AN API FOR C# TO USE CHAT-API IN THE WHATS APP BOT, 
      YOU CAN ADD METHODS, VARIABLES AND ALL YOU NEED FOR THE RIGHT USE
      CONTINUING WITH CONVENTIONS.

      THIS CLASS WAS CREATED USING SINGLETON PATTER DESIGN

      DATE CREATED -> JULY 7TH, 2019
      CREATED BY   -> JESUS EQUIHUA EQUIHUA
    ********************************************************************/
{
    /// <summary>
    ///  Main class for CHAT-API Service
    /// </summary>
    class APIWhatsApp
    {
        private RequestBodySendMessage requestBodySendMessage = new RequestBodySendMessage();
        private static APIWhatsApp INSTANCE_API_WHATSAPP = null;

        /*******************
         **** VARIABLES ****
         *******************/

        /* API CONST */
        const String URL = "https://api.chat-api.com/";
        const String INSTANCE = "instance13637";
        const String TOKEN = "nnpq9kpqqoczvipx";

        /* METHOD CONST */
        const String SEND_MESSAGE = "sendMessage";
        const String LIST_MESSAGES = "messages";

        /// <summary>
        ///     Private constructor for Singleton pattern design
        /// </summary>
        private APIWhatsApp() { }

        /// <summary>
        ///     Returns unique instance
        /// </summary>
        /// <returns></returns>
        public static APIWhatsApp getInstance() {
            if (INSTANCE_API_WHATSAPP == null)
                INSTANCE_API_WHATSAPP = new APIWhatsApp();

            return INSTANCE_API_WHATSAPP;
        }

        /// <summary>
        /// Generate URL base with URL and instance (e.g. https://api.chat-api.com/instance13637/)
        /// </summary>
        /// <returns></returns>
        private String generateURLBase()
        {
            return string.Concat(URL, INSTANCE, "/");
        }

        /// <summary>
        ///  Append token to URL string
        /// </summary>
        /// <returns></returns>
        private String appendToken()
        {
            return string.Concat("?token=", TOKEN);
        }
                                                                             
        /// <summary>
        ///     Execute a HTTP POST Request
        /// </summary>
        /// <param name="URL">URL to make request</param>
        /// <param name="JSON">Params in JSON String</param>
        /// <returns></returns>
        private String HTPPRequest(String URL, String jsonString)
        {
            try
            {
                String outputString = String.Empty;
                String URL_FORMATED = String.Format(URL);
                HttpWebRequest requestObject = (HttpWebRequest)WebRequest.Create(URL_FORMATED);
                requestObject.ContentType = "application/json; charset=utf-8";
                requestObject.Method = "POST";

                using (var streamWriter = new StreamWriter(requestObject.GetRequestStream()))
                { 
                    streamWriter.Write(jsonString);
                    streamWriter.Flush();
                }

                HttpWebResponse responseObject = null;
                responseObject = (HttpWebResponse)requestObject.GetResponse();

                using (Stream stream = responseObject.GetResponseStream())
                {
                    StreamReader streamReader = new StreamReader(stream);
                    outputString = streamReader.ReadToEnd();
                    streamReader.Close();
                }

                return outputString;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Generate the URL necessary to send a message
        /// </summary>
        /// <returns>
        /// returns a valid URL string 
        /// </returns>
        public String generateSendMessageURL()
        {
            return string.Concat(generateURLBase(), SEND_MESSAGE, appendToken());
        }

        /// <summary>
        /// Generate the URL necessary to list messages - CHAT-API returns 100 registers only.
        /// </summary>
        /// <returns></returns>
        public String generateListMessagesURL()
        {
            return string.Concat(generateURLBase(), LIST_MESSAGES, "/", appendToken());
        }

        /// <summary>
        /// Generate the URL necessary to list messages from the message number
        /// </summary>
        /// <param name="LastNumber">From this number</param>
        /// <returns></returns>
        public String generateListMessagesByLastNumberURL(int LastNumber)
        {
            return string.Concat(generateURLBase(), LIST_MESSAGES, "/", appendToken(), "&lastMessageNumber=", LastNumber);
        }

        /// <summary>
        /// Generate the URL necessary to list messages from message number and chat ID
        /// </summary>
        /// <param name="lastNumber">From this number</param>
        /// <param name="chatID">By this chat ID</param>
        /// <returns></returns>
        public String generateListMessageWithLastNumberByChatIDURL(int lastNumber, String chatID)
        {
            return string.Concat(generateURLBase(), LIST_MESSAGES, "/", appendToken(), "&lastMessageNumber=", lastNumber, "&chatId=", chatID);
        }

        /// <summary>
        ///  Send message and returns a ResponseBodyMessage object
        /// </summary>
        /// <param name="phoneNumber">Phone number to send message</param>
        /// <param name="Message">Text you want to send</param>
        /// <returns></returns>
        public ResponseBodyMessage sendMessage(String phoneNumber, String Message)
        {
            try
            {
                requestBodySendMessage.setPhoneNumber(phoneNumber);
                requestBodySendMessage.setMessage(Message);
                String response = HTPPRequest(generateSendMessageURL(), requestBodySendMessage.getJSONString());
                return JsonConvert.DeserializeObject<ResponseBodyMessage>(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    
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
        ///     Returns a JSON String right to send message
        /// </summary>
        /// <returns></returns>
        public String getJSONString()
        {

            return "{\"phone\":\""+phoneNumber+"\",\"body\":\""+Message+"\"}";
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
            this.phoneNumber = formatNumber(phoneNumber);
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

    /// <summary>
    ///  Body for message response
    /// </summary>
    class ResponseBodyMessage
    {
        public Boolean sent { get; set; }
        public String id { get; set; }
        public String message { get; set; }

        public Boolean getSent() { return this.sent; }
        public String getId() { return this.id; }
        public String getMessage() { return this.message; }
    }

}
