# WhatsApp-CSharp-ChatAPI
This is a Class to use the ChatAPI service in C#

# Service URL 
https://chat-api.com/en/?lang=ES

This repository will be updated according my own needs.
Feel free to pull your request to this repository.

# Explanation
<strong>This class is under singleton pattern design</strong>
<p>
	This means you can use one instance in all your application only.
	For getting instance in any block in your application you need to type the follow code:
	<strong>APIWhatsApp WhatsAppApi = APIWhatsApp.getInstance();</strong>
</p>

<strong>APIWhatsApp</strong>
<p>
	This is the main class, it contains necessary methods to send messages to a WhatsApp number and methods to list all messages.
</p>
<strong>RequestBodySendMessage</strong>
<p>
	This class is an structure to generate correct body for sending messages.
</p>
<strong>ResponseBodyMessage</strong>
<p>
	This class is an structure to get the response from server and serialize it into object structure.
</p>

# Content
<strong>APIWhatsApp Class</strong>

<strong>API CONSTANTS</strong>
<ul>
	<li>
		URL
		<p>Service provider URL</p>
	</li>
	<li>
		INSTANCE
		<p>Instance name (given by provider)</p>
	</li>
	<li>
		TOKEN
		<p>Token number (given by provider)</p>
	</li>
</ul>

<strong>METHOD CONSTANTS</strong>
<ul>
	<li>
		SEND_MESSAGE
		<p>Method name for sending messages</p>
	</li>
	<li>
		LIST_MESSAGES
		<p>Method name for listing messages</p>
	</li>
</ul>

<strong>METHODS</strong>
<ul>
	<li>
		<strong>generateURLBase()</strong>
		<p>Generate URL base concatening URL and INSTANCE.</p>		
		<p><strong>Modifier: </strong> Private</p>
		<p><strong>Parameters: </strong> None</p>
		<p><strong>Returns: </strong> String</p>
	</li>
	<li>
		<strong>appendToken()</strong>	
		<p>Append token to URL String</p>
		<p><strong>Modifier: </strong> Private</p>
		<p><strong>Parameters: </strong> None</p>
		<p><strong>Returns: </strong> String</p>
	</li>
	<li>
		<strong>HTPPRequest(String URL, String jsonString)</strong>	
		<p>Append token to URL String</p>
		<p><strong>Modifier: </strong> Private</p>
		<p><strong>Parameters: </strong></p>
		<ul>
			<li>
				<strong>URL</strong>
				<p><strong>Type: </strong> String</p>
				<p>URL to request (e.g. generateSendMessageURL())</p>
			</li>
			<li>
				<strong>jsonString</strong>
				<p><strong>Type: </strong> String</p>
				<p>JSON String with the right parameters</p>
			</li>
		</ul>
		<p><strong>Returns: </strong> String</p>
	</li>
	<li>
		<strong>generateSendMessageURL()</strong>
		<p>Generate the URL necessary to send a message</p>
		<p><strong>Modifier: </strong> Public</p>
		<p><strong>Parameters: </strong> None</p>
		<p><strong>Returns: </strong> String</p>
	</li>
	<li>
		<strong>generateListMessagesURL()</strong>
		<p>Generate the URL necessary to list messages</p>
		<p><strong>Modifier: </strong> Public</p>
		<p><strong>Parameters: </strong> None</p>
		<p><strong>Returns: </strong> String</p>
		<p><strong>NOTE: </strong> Chat-API returns 100 registers only.</p>
	</li>
	<li>
		<strong>generateListMessagesByLastNumberURL(int LastNumber)</strong>
		<p>Generate the URL necessary to list messages from a message number.</p>
		<p><strong>Modifier: </strong> Public</p>
		<p><strong>Parameters: </strong></p>
		<ul>
			<li>
				<strong>LastNumber</strong>
				<p><strong>Type: </strong> int</p>
				<p>Message number to search from it.</p>
			</li>
		</ul>
		<p><strong>Returns: </strong> String</p>
	</li>
	<li>
		<strong>generateListMessageWithLastNumberByChatIDURL(int lastNumber, string chatID)</strong>
		<p>Generate URL necessary to list messages from message number and associated to a chat ID</p>
		<p><strong>Modifier: </strong> Public</p>
		<p><strong>Parameters: </strong></p>
		<ul>
			<li>
				<strong>lastNumber</strong>
				<p><strong>Type: </strong> int</p>
				<p>Message number to search from it.</p>
			</li>
			<li>
				<strong>chatID</strong>
				<p><strong>Type: </strong> String</p>
				<p>Chat ID to search messages associated to it</p>
			</li>
		</ul>
		<p><strong>Returns: </strong> String</p>
	</li>
	<li>
		<strong>sendMessage(String phoneNumber, String Message)</strong>
		<p>Send message and returns a ResponseBodyMessage object.</p>
		<p><strong>Modifier: </strong> Public</p>
		<p><strong>Parameters: </strong></p>
		<ul>
			<li>
				<strong>phoneNumber</strong>
				<p><strong>Type: </strong> String</p>
				<p>Phone number which receive the message.</p>
			</li>
		</ul>
		<p><strong>Returns: </strong> ResponseBodyMessage</p>
	</li>
</ul>


<strong>RequestBodySendMessage Class</strong>

<strong>CONSTANTS</strong>
<ul>
	<li>
		COUNTRY_AREA
		<p>Area of the country (e.g. Mexico 52).</p>
	</li>
</ul>

<strong>VARIABLES</strong>
<ul>
	<li>
		phoneNumber
		<p>Phone number which receives message.</p>
	</li>
	<li>
		Message
		<p>Message that you want to send.</p>
	</li>
</ul>

<strong>CONSTRUCTOR</strong>
<ul>
	<li>
		<strong>RequestBodySendMessage()</strong>
		<p>Empty constructor</p>
		<p><strong>Parameters: </strong> None</p>
	</li>
	<li>
		<strong>RequestBodySendMessage(string phoneNumber, string Message)</strong>
		<p>Set phone number and message.</p>
		<p><strong>Parameters: </strong></p>
		<ul>
			<li>
				<strong>phoneNumber</strong>
				<p><strong>Type: </strong> String</p>
				<p>Phone number which receives message.</p>
			</li>
			<li>
				<strong>Message</strong>
				<p><strong>Type: </strong> String</p>
				<p>Message you want to send.</p>
			</li>
		</ul>
	</li>
</ul>

<strong>METHODS</strong>
<ul>
	<li>
		<strong>getJSON()</strong>
		<p>Returns a JSON in Dictionary format</p>
		<p><strong>Modifier: </strong> Public</p>
		<p><strong>Parameters: </strong> None</p>
		<p><strong>Returns: </strong> Dictionary<string,string></p>
	</li>
	<li>
		<strong>getJSONString()</strong>
		<p>Returns a JSON string right to send message</p>
		<p><strong>Modifier: </strong> Public</p>
		<p><strong>Parameters: </strong> None</p>
		<p><strong>Returns: </strong> String</p>
	</li>
	<li>
		<strong>getPhoneNumber()</strong>
		<p>Returns phone number</p>
		<p><strong>Modifier: </strong> Public</p>
		<p><strong>Parameters: </strong> None</p>
		<p><strong>Returns: </strong> String</p>
	</li>
	<li>
		<strong>setPhoneNumber(string phoneNumber)</strong>
		<p>Set phone number</p>
		<p><strong>Modifier: </strong> Public</p>
		<p><strong>Parameters: </strong></p>
		<ul>
			<li>
				<strong>phoneNumber</strong>
				<p><strong>Type: </strong> String</p>
				<p>Phone number</p>
			</li>
		</ul>
		<p><strong>Returns: </strong> NONE</p>
	</li>
	<li>
		<strong>getMessage()</strong>
		<p>Returns the message.</p>
		<p><strong>Modifier: </strong> Public</p>
		<p><strong>Parameters: </strong> None</p>
		<p><strong>Returns: </strong> String</p>
	</li>
	<li>
		<strong>setMessage(string Message)</strong>
		<p>Set message</p>
		<p><strong>Modifier: </strong> Public</p>
		<p><strong>Parameters: </strong></p>
		<ul>
			<li>
				<strong>Message</strong>
				<p><strong>Type: </strong> String</p>
				<p>Message</p>
			</li>
		</ul>
		<p><strong>Returns: </strong> NONE</p>
	</li>
	<li>
		<strong>formatNumber(string phoneNumber)</strong>
		<p>Format phone number if it is missing country area</p>
		<p><strong>Modifier: </strong> Private</p>
		<p><strong>Parameters: </strong></p>
		<ul>
			<li>
				<strong>phoneNumber</strong>
				<p><strong>Type: </strong> String</p>
				<p>Phone number</p>
			</li>
		</ul>
		<p><strong>Returns: </strong> String</p>
	</li>
</ul>

<strong>ResponseBodyMessage Class</strong>

<strong>VARIABLES</strong>
<ul>
	<li>
		sent
		<p><strong>Type: </strong> Boolean</p>
	</li>
	<li>
		id
		<p><strong>Type: </strong> String</p>
	</li>
	<li>
		message
		<p><strong>Type: </strong> String</p>
	</li>
</ul>

<strong>METHODS</strong>
<ul>
	<li>
		<strong>getSent()</strong>
		<p>Returns the value for sent variable</p>
		<p><strong>Modifier: </strong> Public</p>
		<p><strong>Parameters: </strong> None</p>
		<p><strong>Returns: </strong> Boolean</p>
	</li>
	<li>
		<strong>getId()</strong>
		<p>Returns the value for id variable</p>
		<p><strong>Modifier: </strong> Public</p>
		<p><strong>Parameters: </strong> None</p>
		<p><strong>Returns: </strong> String</p>
	</li>
	<li>
		<strong>getMessage()</strong>
		<p>Returns the value for message variable</p>
		<p><strong>Modifier: </strong> Public</p>
		<p><strong>Parameters: </strong> None</p>
		<p><strong>Returns: </strong> String</p>
	</li>
</ul>

# Conditions
Follow the conventions.

# Notes
If you find a mistake let me know. :D
