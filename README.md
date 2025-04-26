# Xml Validator

Simple xml validator

### Usage

Build the project and run checker.exe from command line:

_Example_


### Notes

A string is considered a valid XML string if it meets the following conditions:

- Every opening tag must have a matching closing tag, and every closing tag must correspond to an opening tag.
- Tags must be properly nested, meaning the tag that opens first must close last. For example, `<tutorial><topic>XML</topic></tutorial>` is valid, whereas `<tutorial><topic>XML</tutorial></topic>` is not.
- If any XML tag contains an empty string, the validation result is false. For example `<></>` is invalid.
  
