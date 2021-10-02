# eSchool - Microservice and Containers based open source School Administration Software

## Linux Build Status for 'main' branch

| Image                     | Status                                                                                                                                                                                                                                               | Image                 | Status                                                                                                                                                                                                                                   |
| ------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Enrolling.API             | [![Enrolling.API](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/enrolling.api.yml/badge.svg?branch=main)](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/enrolling.api.yml)                                       | ESchool.GraphQL       | [![ESchool.GraphQL](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/eschool.graphql.yml/badge.svg?branch=main)](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/eschool.graphql.yml)                     |
| CertificateProcessing.API | [![CertificateProcessing.API](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/certificate-processing.api.yml/badge.svg?branch=main)](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/certificate-processing.api.yml) | Frontend.Blazor       | [![Frontend.Blazor](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/frontend.blazor.yml/badge.svg?branch=main)](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/frontend.blazor.yml)                     |
| WebStatus                 | [![WebStatus](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/webstatus.yml/badge.svg?branch=main)](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/webstatus.yml)                                                   | CodeQL                | [![CodeQL](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/codeql-analysis.yml/badge.svg?branch=main)](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/codeql-analysis.yml)                              |
| ExamManagement.API        | [![ExamManagement.API](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/exam-management.api.yml/badge.svg?branch=main)](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/exam-management.api.yml)                      | LibraryManagement.API | [![LibraryManagement.API](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/library-management.api.yml/badge.svg?branch=main)](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/library-management.api.yml) |
| ResultProcessing.API      | [![ResultProcessing.API](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/result-processing.api.yml/badge.svg?branch=main)](https://github.com/OpenCodeFoundation/eSchool/actions/workflows/result-processing.api.yml)                |                       |                                                                                                                                                                                                                                          |

## System requirements

### Recommended Hardware requirements for Windows

- Windows 10 Pro, Education or Enterprise
- 64-bit Processor with Second Level Address Translation (SLAT)
- CPU support for VM Monitor Mode Extension (VT-c on Intel CPU's)
- Virtualization must enabled in BIOS. Typically, virtualization is enabled by default
  - This is different from having Hyper-V enabled

### Software requirements for Windows

- Docker Community Edition (aka. Docker for Windows) - Requires Windows 10 Pro 64 bits and Hyper-V enabled
- Latest **.NET 5.0 SDK** from: https://www.microsoft.com/net/download
- (Optional) Visual Studio 2019
- (Optional) Visual Studio Code

> NOTE: If you can install `Docker Desktop for Windows` following the instruction in [https://docs.docker.com/docker-for-windows/install/](https://docs.docker.com/docker-for-windows/install/), then you are good to go.

## How to Run

After installing `Docker` in your machine, just run

```bash
$ docker-compose up
```

in terminal from project's root folder. The first run can take 30 mins to 1 hour depending on your internet speed, as it will download required docker images from the docker hub. After everything starts up, you can access the `Enrolling.API` swagger UI by visiting [http://localhost:5102/swagger/](http://localhost:5102/swagger/)

## How to Run on Visual studio

- Open **eSchool** project on Visual studio then **right click** on **docker-compose** project.
 ![docker-compose-up](https://user-images.githubusercontent.com/39862861/123513690-3b280a00-d6b0-11eb-9624-cf568bb194e7.png)
- From the menu select **Set as Startup Project**.
- Now, run the project by clicking **docker-compose** from the **main status menu bar**.

**Note:** You have to run **Docker desktop** before running **eSchool** project on **visual studio**

### Service URLs

- eSchool Frontend (Blazor) - [http://localhost:5200/](http://localhost:5200/)
- eSchool Gateway (GraphQL) - [http://localhost:5101/graphql/](http://localhost:5101/graphql/)
- WebStatus - [http://localhost:5107/](http://localhost:5107/)
- Enrolling.API (REST - Swagger) - [http://localhost:5102/swagger/](http://localhost:5102/swagger/)
- Enrolling.API (GraphQL - Banana Cake Pop) - [http://localhost:5102/graphql/](http://localhost:5102/graphql/)
- Distributed Tracing (Jaeger) - [http://localhost:16686](http://localhost:16686)
- Logging (Seq) - [http://localhost:5140/](http://localhost:5140/)

## Tech & Tools

- .NET Core
- Docker
- Orchestrators: Kubernetes
- Visual Studio
- SQL Server
- API Gateway
- GraphQL
- Blazor
- Serilog(Logging)
- Jaeger(Distributed tracing)

## Contributing

Everyone is welcome to contribute, whether it's in the form of code, documentation, bug reports, feature requests, or anything else. See the [Contributing](https://github.com/OpenCodeFoundation/eschool/blob/master/CONTRIBUTING.md) guide for more details.

## Sending feedback and pull requests

As mentioned, we'd appreciate your feedback, improvements and ideas.
You can create new issues at the issues section, do pull requests and/or send emails to **techcombd@outlook.com**

### Thanks to all the people and bot (😉) who have contributed

[![contributors](https://contributors-img.web.app/image?repo=OpenCodeFoundation/eSchool)](https://github.com/OpenCodeFoundation/eSchool/graphs/contributors)

## License

Code licensed under the [MIT License](https://github.com/OpenCodeFoundation/eSchool/blob/master/LICENSE).
