# XML Validator

Simple xml validator

### Usage

Build the project and run `checker.exe` from the command line.

**Input:** An XML string, passed as the first command line argument.  
**Output:** Prints "Valid" if the XML string is valid, otherwise prints "Invalid", followed by a newline.

_Example_

```
checker.exe <root><child></child><child></child></root>
Valid
```

```
checker.exe <root></child></root>
Invalid
```

### Features

- Basic XML tag validation
- Proper tag nesting verification
- Matching of opening and closing tags
- Exact tag name comparison, including attributes or any string inside the tags
- Detection of empty tags

### Limitations
- No support for self-closing tags (e.g., <tag />)
- No support for XML namespaces
- No handling of whitespace or formatting inside tags
- No partial attribute matching (attributes must match exactly)

### Notes

A string is considered a valid XML string if it meets the following conditions:

- Every opening tag must have a matching closing tag, and every closing tag must correspond to an opening tag.
- Tags must be properly nested, meaning the tag that opens first must close last. For example, `<tutorial><topic>XML</topic></tutorial>` is valid, whereas `<tutorial><topic>XML</tutorial></topic>` is not.
- The strings inside each opening and corresponding closing tag must be identical. For example:
  - `<tutorial date="01/01/2000">XML</tutorial>` is invalid because the tags differ
  - `<tutorial date="01/01/2000">XML</tutorial date="01/01/2000">` is valid.
- If any XML tag contains an empty string, the validation result is false. For example `<></>` is invalid.
- Whitespace also must match exactly inside the opening and corresponding closing tags. For example `<xml></xml >` is invalid.
  
