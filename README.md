# 🚧 Headless Services REST Layout Not Found

This solution demonstrates how to fix the [Sitecore Headless Services][1] REST Layout Service so that an item with no layout behaves the same as a non-existent item.

The implementation differs between Sitecore versions, so there is one project per range of versions:

| Sitecore       | Headless Services | Project                                                                |
| -------------- | ----------------- | ---------------------------------------------------------------------- |
| 10.5           | 23.0.0            | [`platform-10.4-10.5`](src/Feature/LayoutService/platform-10.4-10.5)   |
| 10.4.X         | 22.0.0            | [`platform-10.4-10.5`](src/Feature/LayoutService/platform-10.4-10.5)   |
| 10.3.X         | 21.0.0 - 21.0.1   | [`platform-10.2-10.3`](src/Feature/LayoutService/platform-10.2-10.3)   |
| 10.2.X         | 19.0.0 - 20.0.2   | [`platform-10.2-10.3`](src/Feature/LayoutService/platform-10.2-10.3)   |
| 10.1.X         | 16.0.0 - 18.0.0   | [`platform-9.0.2-10.1`](src/Feature/LayoutService/platform-9.0.2-10.1) |
| 10.0.X         | 14.0.0 - 15.0.1   | [`platform-9.0.2-10.1`](src/Feature/LayoutService/platform-9.0.2-10.1) |
| 9.3            | 13.0.0            | [`platform-9.0.2-10.1`](src/Feature/LayoutService/platform-9.0.2-10.1) |
| 9.2            | 12.0.0            | [`platform-9.0.2-10.1`](src/Feature/LayoutService/platform-9.0.2-10.1) |
| 9.1.X          | 11.0.0 - 11.1.0   | [`platform-9.0.2-10.1`](src/Feature/LayoutService/platform-9.0.2-10.1) |
| 9.0 Update-2   | 11.0.0            | [`platform-9.0.2-10.1`](src/Feature/LayoutService/platform-9.0.2-10.1) |

> [!Note]
> Sitecore 9.0 Initial Release and Sitecore 9.0 Update-1 are not featured because there was no final JavaScript Services release for those versions.

## 🏗️ Setup

1. Install a new instance of Sitecore with JavaScript Services or Headless Services.
2. Compare the REST Layout Service response of an item that does not exist (e.g., `/sitecore/api/layout/render/jss?item=/i-dont-exist&sc_apikey=api-key-here`) to an item with no layout (e.g., `/sitecore/api/layout/render/jss?item=/sitecore/content&sc_apikey=api-key-here`). Observe the difference in behavior.
3. Update the `publishUrl` in [`PublishSettings.Platform.targets`](PublishSettings.Platform.targets) to your Sitecore installation's web root (e.g., `C:\inetpub\wwwroot\sc1050.sc`).
4. Build the solution.
5. Publish the relevant project to Sitecore from Visual Studio.
6. Compare the REST Layout Service response of an item that does not exist (e.g., `/sitecore/api/layout/render/jss?item=/i-dont-exist&sc_apikey=api-key-here`) to an item with no layout (e.g., `/sitecore/api/layout/render/jss?item=/sitecore/content&sc_apikey=api-key-here`). Observe the same behavior.

[1]: https://developers.sitecore.com/downloads/Sitecore_Headless_Rendering
