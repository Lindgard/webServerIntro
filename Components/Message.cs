//* The Objects our application needs.
//* These can be moved to other files, and usually are.
//! Think of them as components like in React.

//* The Object ("Form") the user needs to fill out
//* and send us
class MessageCreateInfo
{
    public required string Alias {get; set;}
    public required string Content {get; set;}
}

//* The Object that defines hat e persist in our application
class Message
{
    //* Properties(props) that this object consists of
    public Guid Id { get; set; }
    public string Alias { get; set; }
    public string Content{ get; set; }

    //*The constructor, defining ho new instances
    //* of this object is created
    public Message(MessageCreateInfo createInfo)
    {
        //* Generate a new Globaly Unique Identifier
        Id = Guid.NewGuid();
        //* We have no rules for what valid Aliases are 
        //* beyond a string of any length
        Alias = createInfo.Alias;
        //* Nor what is valid content
        Content = createInfo.Content;
    }
}