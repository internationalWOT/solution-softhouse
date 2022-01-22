# Solution softhouse

This is a simple console application for translating a text based file into an XML 

 

To run the application, simply open it in Visual studio (2019 or later). When running the application you will be prompted to provide a search path to a .txt file.  

In the solution you will also find a small pre-provided file called TestData.txt where if you do not have access to any text files needed to run the application. 

 

The application will read the content of the provided file line by line and determine what it is supposed to do after a specific ruleset. This ruleset is  somewhat hardcoded and works as follows: 

    P|firstname|lastname        -> person 

    T|mobile|landline           -> phone 

    A|street|city|zipcode       -> address 

    F|name|born                 -> family 

    P can be followed by T, A and F 

     F can be followed by T and A 

    The root element is always people 

    P is a list of people. 

    F is a listitem of family members . 

 

If the first letter on each line is not P,T,A or F the row will not be processed 

If the second letter on each line is not the correctly configured delimiter, which in this case is  the letter “|”. The row will not be processed 

A line is defined by the fact that there is a “new line” character present in the file.  

 

There are some basic unit tests present that validates that a correctly formed XML is created if an text input provided by these termes descibed above is inserted into the application. 