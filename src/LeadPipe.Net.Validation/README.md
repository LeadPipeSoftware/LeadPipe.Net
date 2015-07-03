# LeadPipe.Net.Validation

The validation library provides a suite of attributes that extend Microsoft's own System.ComponentModel.DataAnnotations library. In addition, there are handy extension methods and a stand-alone validator.

## Validation Attributes

Validation attributes can really help to make your code easier to read and much more intention revealing. For example, you can replace this:

```csharp
public string Name
{
	get { return name; }
	set
	{
		if (value == null || value == string.NullOrEmpty())
		{
			throw new InvalidEntityException("You must supply a name!");
		}
		
		if (value.Any(char.IsWhiteSpace))
		{
			throw new InvalidEntityException("Names cannot contain whitespace!");
		}
		
		name = value;
	}
}
```

With this:

```csharp
[Required]
[NoWhitespace]
public string Name { get; set; }
```

### Alpha

Prevents any non-alpha (A-Z or a-z) characters.

### Alphanumeric

Prevents non-alphanumeric characters.

### ExtendedCharacter

Prevents extended ASCII characters.

### Maximum

Prevents values greater than a maximum value.

### Minimum

Prevents values less than than a minimum value.

### MaximumLength

Prevents strings longer than a maximum value.

### MinimumLength

Prevents strings shorter than a minimum value.

### NoLeadingWhitespace

Prevents leading whitespace.

### NoLowerCase

Prevents lower case characters.

### NoTrailingWhitespace

Prevents trailing whitespace.

### NoUpperCase

Prevents upper case characters.

### NoWhitespace

Prevents whitespace characters.

### Numeric

Prevents non-numeric characters.

### PrintableCharacter

Prevents non-printable characters.

## Object Extensions

Provides handy extension methods such as object.Validate() and object.IsValid()

## Validator

A stand-alone validator that will handle single or multiple entities.
