# [0.6.0](https://github.com/OpenCodeFoundation/eSchool/compare/v0.3.0...v0.6.0) (2020-12-02)

After 3 months, we are publishing new version. We are skipping v0.4.0 and v0.5.0.

### Bug Fixes

* **doc:** fix GraphQL gateway URL ([bf17307](https://github.com/OpenCodeFoundation/eSchool/commit/bf173074c5bc6fbee4a0ee53662909a38c609085))


### Features

* **enrolling:** add GraphQL support ([#239](https://github.com/OpenCodeFoundation/eSchool/issues/239)) ([16abcfe](https://github.com/OpenCodeFoundation/eSchool/commit/16abcfe912f79e76a726d5eb435289528529f587))
* **enrolling:** replace deprecated `set-env` command ([#236](https://github.com/OpenCodeFoundation/eSchool/issues/236)) ([eebd832](https://github.com/OpenCodeFoundation/eSchool/commit/eebd8322bc2f2b1fd130efdb9a4a4a82a4190d29))
* **eschool-graphql:** add build pipelines ([#242](https://github.com/OpenCodeFoundation/eSchool/issues/242)) ([813d033](https://github.com/OpenCodeFoundation/eSchool/commit/813d0330d231ec6ba5f07d744ffd36cc891996ee))
* **frontend-blazor:** add blazor web assembly project ([#243](https://github.com/OpenCodeFoundation/eSchool/issues/243)) ([9740132](https://github.com/OpenCodeFoundation/eSchool/commit/9740132e99b6f78f09d93992f5c575e16521eedd))
* **frontend-blazor:** read frontend configuration from host service ([9a17cfe](https://github.com/OpenCodeFoundation/eSchool/commit/9a17cfeaea309b7774f36b7a1e987d96aedd6149))
* add graphql api gateway ([#240](https://github.com/OpenCodeFoundation/eSchool/issues/240)) ([dc0e813](https://github.com/OpenCodeFoundation/eSchool/commit/dc0e8132d914f509cf4429610abb85cd62d0ce10))
* **joining:** remove joining service ([#234](https://github.com/OpenCodeFoundation/eSchool/issues/234)) ([d5835ca](https://github.com/OpenCodeFoundation/eSchool/commit/d5835ca5eca40b89fd7a54c7ddb87a41189ab9a3)), closes [#169](https://github.com/OpenCodeFoundation/eSchool/issues/169)
* **lib:** update open telemetry to latest RC version ([#238](https://github.com/OpenCodeFoundation/eSchool/issues/238)) ([3d599cf](https://github.com/OpenCodeFoundation/eSchool/commit/3d599cf137292826a74b1d75f25878d7cb442f2e))
* update services to .NET 5 ([#233](https://github.com/OpenCodeFoundation/eSchool/issues/233)) ([d543280](https://github.com/OpenCodeFoundation/eSchool/commit/d54328012b2d397f29b5e50db5cf3dcc3b49fed3))
* **pipeline:** add spell check to pull request ([18f5b0d](https://github.com/OpenCodeFoundation/eSchool/commit/18f5b0d3fc48179265aa739f79339e1674029d02)), closes [#193](https://github.com/OpenCodeFoundation/eSchool/issues/193)
* **web-status:** replace third party library files with libman package manager ([0343337](https://github.com/OpenCodeFoundation/eSchool/commit/0343337c04f049eed0c4f735b18a3fb83239d2df))



# [0.3.0](https://github.com/OpenCodeFoundation/eSchool/compare/v0.2.0...v0.3.0) (2020-08-01)


### Features

* **deployment:** Initial deployment script  ([#178](https://github.com/OpenCodeFoundation/eSchool/issues/178)) ([5344488](https://github.com/OpenCodeFoundation/eSchool/commit/5344488dd5b13f81423ce4fce4cc256223957569)), closes [#146](https://github.com/OpenCodeFoundation/eSchool/issues/146)
* **enrolling:** add open telemetry integration ([eb751de](https://github.com/OpenCodeFoundation/eSchool/commit/eb751ded855a5923ef1f42707c9476e87e36a825))
* **enrolling:** publish docker image to docker hub ([#177](https://github.com/OpenCodeFoundation/eSchool/issues/177))Closes [#173](https://github.com/OpenCodeFoundation/eSchool/issues/173) ([43fb95c](https://github.com/OpenCodeFoundation/eSchool/commit/43fb95c3bb5039a2d47f2ed0b5e2fa496603c1d0))
* **enrolling:** update enrolling service to .NET 5.0 ([#186](https://github.com/OpenCodeFoundation/eSchool/issues/186)) ([a03d284](https://github.com/OpenCodeFoundation/eSchool/commit/a03d284d9ccdeb4127ce4377084557ffffb82120)), closes [#167](https://github.com/OpenCodeFoundation/eSchool/issues/167)
* **pipeline:** improve pipeline trigger ([60e7fb7](https://github.com/OpenCodeFoundation/eSchool/commit/60e7fb7efce0db773d6d8be3d8698c1ca3b0bad0))



## [0.2.0](https://github.com/OpenCodeFoundation/eSchool/compare/62af44a5c22bd198491bc95684b0a136f0a2b9cd...v0.2.0) (2020-07-01)


### Bug Fixes

* **enrolling:** change email address as required field ([e3da303](https://github.com/OpenCodeFoundation/eSchool/commit/e3da303c162a0a54158d5b8c07a919e37bd4ae44))
* **enrolling:** modify source path for code coverage ([#166](https://github.com/OpenCodeFoundation/eSchool/issues/166)) ([2845652](https://github.com/OpenCodeFoundation/eSchool/commit/284565244a4a278fbb3bbbb0a30d85f0f66ffc1f)), closes [#164](https://github.com/OpenCodeFoundation/eSchool/issues/164)
* **enrolling:** update NuGet packages ([#161](https://github.com/OpenCodeFoundation/eSchool/issues/161)) ([d4797b4](https://github.com/OpenCodeFoundation/eSchool/commit/d4797b4fb527ee2a664c037761cb0d123e44d03f))
* broken identity service removed ([62af44a](https://github.com/OpenCodeFoundation/eSchool/commit/62af44a5c22bd198491bc95684b0a136f0a2b9cd)), closes [#95](https://github.com/OpenCodeFoundation/eSchool/issues/95)


### Features

* add GitHub code scanning ([#165](https://github.com/OpenCodeFoundation/eSchool/issues/165)) ([0cbc451](https://github.com/OpenCodeFoundation/eSchool/commit/0cbc4519ae075f91a9d3d2af41af2755481d899e))
* **enrolling:** enable logging every command and query processing ([0ac94ec](https://github.com/OpenCodeFoundation/eSchool/commit/0ac94ec4aea4a4567db7487282e4daa267fafccb))
* **enrolling:** use mediatR to handle query ([70114d7](https://github.com/OpenCodeFoundation/eSchool/commit/70114d761aae5fcbe6f1ec9511c1578d46680e85))
* enable w3c trace context support ([#159](https://github.com/OpenCodeFoundation/eSchool/issues/159)) ([e1a69b8](https://github.com/OpenCodeFoundation/eSchool/commit/e1a69b8a8e95a84d60c988d42a0dd70ded6f06fb))
* **service-status:** use sql database to store service health status ([#157](https://github.com/OpenCodeFoundation/eSchool/issues/157)) ([43b1148](https://github.com/OpenCodeFoundation/eSchool/commit/43b114895dfc06a1efe053d8b3967429807853a2))
