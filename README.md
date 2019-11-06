# eSchool - Microservice and Containers based open source School Administration Software

## Linux Build Status for 'master' branch

|                                                                                                    Identity API                                                                                                    |                                                                                                    Enrolling.API                                                                                                    |                                                                                                      WebStatus                                                                                                      |
| :----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: | :-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: | :-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------: |
| [![Build Status](https://dev.azure.com/OpenCodeFoundation/eSchool/_apis/build/status/identity?branchName=master)](https://dev.azure.com/OpenCodeFoundation/eSchool/_build/latest?definitionId=1&branchName=master) | [![Build Status](https://dev.azure.com/OpenCodeFoundation/eSchool/_apis/build/status/Enrolling?branchName=master)](https://dev.azure.com/OpenCodeFoundation/eSchool/_build/latest?definitionId=4&branchName=master) | [![Build Status](https://dev.azure.com/OpenCodeFoundation/eSchool/_apis/build/status/WebStatus?branchName=master)](https://dev.azure.com/OpenCodeFoundation/eSchool/_build/latest?definitionId=5&branchName=master) |
|                             [![Actions Status](https://github.com/OpenCodeFoundation/eSchool/workflows/Identity.API/badge.svg)](https://github.com/OpenCodeFoundation/eSchool/actions)                             |                             [![Actions Status](https://github.com/OpenCodeFoundation/eSchool/workflows/Enrolling.API/badge.svg)](https://github.com/OpenCodeFoundation/eSchool/actions)                             |                               [![Actions Status](https://github.com/OpenCodeFoundation/eSchool/workflows/WebStatus/badge.svg)](https://github.com/OpenCodeFoundation/eSchool/actions)                               |

## System requirements
### Recommended Hardware requirements for Windows

- Windows 10 Pro, Education or Enterprise
- 64-bit Processor with Second Level Address Translation (SLAT)
- CPU support for VM Monitor Mode Extension (VT-c on Intel CPU's)
- Virtualization must enabled in BIOS. Typically, virtualization is enabled by default
  - This is different from having Hyper-V enabled

### Software requirements for Windows

- Docker Community Edition (aka. Docker for Windows) - Requires Windows 10 Pro 64 bits and Hyper-V enabled
- Latest **.NET Core 3.0 SDK** from: https://www.microsoft.com/net/download
- (Optional) Visual Studio 2019
- (Optional) Visual Studio Code

> NOTE: If you can install `Docker Desktop for Windows` following the instruction in [https://docs.docker.com/docker-for-windows/install/](https://docs.docker.com/docker-for-windows/install/), then you are good to go.

## How to Run

After installing `Docker` in your machine, just run

```bash
$ docker-compose up
```

in terminal from project's root folder. The first run can take 30 mins to 1 hour depending on your internet speed, as it will download required docker images from the docker hub. After everything starts up, you can access the `Enrolling.API` swagger UI by visiting [http://localhost:5102/swagger/](http://localhost:5102/swagger/)

### Service URLs
* WebStatus - [http://localhost:5107/](http://localhost:5107/)
* Enrolling.API - [http://localhost:5102/swagger/](http://localhost:5102/swagger/)
* Identity - [http://localhost:5105/](http://localhost:5105/)


## Tech & Tools
- .NET Core
- Docker
- Orchestrators: Kubernetes
- Visual Studio
- MongoDB
- SQL Server
- Azure DevOps
- Redis
- RabbitMQ

## Contributing
Everyone is welcome to contribute, whether it's in the form of code, documentation, bug reports, feature requests, or anything else. See the contributing guide for more details.

## Sending feedback and pull requests
As mentioned, we'd appreciate your feedback, improvements and ideas.
You can create new issues at the issues section, do pull requests and/or send emails to **techcombd@outlook.com**

## License
Code licensed under the [MIT License](https://github.com/OpenCodeFoundation/eSchool/blob/master/LICENSE).