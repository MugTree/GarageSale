## About...

Basic .NET command line app using data from a mock server to show basic understanding of object mapping, serial and deserialiation c# .NET

## Needs

logging

### App uses a mock server

https://natenho.github.io/Mockaco/

1. Start up the mock server

   `docker run -it --rm -p 5000:5000 -v $(pwd)/Mocks:/app/Mocks natenho/mockaco`

2. Start the dot.net command line app
