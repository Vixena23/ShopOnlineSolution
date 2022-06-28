<div id="top"></div>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li><a href="#api">Api</a></li>
    <li><a href="#client">Client</a></li>
    <li><a href="#tests">Test</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

A project is a simple online store, where i am testing various solutions, such as:
- Rest API,
- Blazor assembly
- Unit and integration testing with xUnit

Remember that I am working on a project all the time and that many solutions can probably be done in a better way.

### Built With

* [ASP .NET CORE API](https://docs.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-6.0)
* [Entity Framework](https://docs.microsoft.com/en-us/ef/)
* [BlazorWebAssembly](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor)
* [Bootstrap](https://getbootstrap.com)
* [XUnit](https://xunit.net/)
* [Moq](https://github.com/moq/moq)
* [FluentAssertions](https://fluentassertions.com/)


<!-- API -->
## Api

<!-- CLIENT -->
## Client

<!-- TESTS -->
## Tests

## Unit tests

## Integration tests

I had some serious problems getting this topic started. I could write simple tests to controllers for 'get' requests, but didn't know what to do with database editing requests such as post or put.

I found three solutions that I liked the most.

### --- Test DB
The first involves creating a test database with test data, and then performing tests on it.
### --- Repository design pattern (which i used)
The second is to use the 'repository' design pattern and define the data returned by this repository in advance (using Moqu).
### --- Transactions
The last one assumes the use of transactions when querying the database and then not saving them (so that the database is not updated).
 
<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>
