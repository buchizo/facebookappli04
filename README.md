Facebook + Open Graph Sample
==
このプロジェクトは"無料クラウドでできるFacebookアプリ開発入門" 第4回のサンプル  
アプリケーションです。

プロジェクトについて
----
2つのVisual Studio 2010 / Visual Web Developer 2010 Express用ソリューションを  
公開しています。

+ OpenGraphSample  
記事内で解説しているサンプルアプリケーションです。

+ OpenGraphSample-After  
記事内のコードをベースに見た目や認証部分をカスタマイズしたものです。

OpenGraphSample
----
#### 環境 ####
以下の環境で作成しています。

+ Windows 7 SP1 x64 JPN
+ Visual Web Developer 2012 Express SP1
	+ ASP.NET MVC 3
+ Windows Azure SDK for .NET 1.6

#### 利用方法 ####
1. .\OpenGraphSample\OpenGraphWeb\Views\Gift フォルダにある Details.cshtml ファイルの  
Viewbag.AppId と ViewBag.AppNamespace に自身のFacebookアプリのAppId,AppNamespaceを  
それぞれ設定します。

2. Windows AzureプロジェクトのOpenGraphSampleにてWindows Azure用サービスパッケージを  
生成し、Windows Azure上のホストサービスにデプロイします。

OpenGraphSample-After
----
#### 環境 ####
以下の環境で作成しています。

+ Windows 7 SP1 x64 JPN
+ Visual Studio 2010 SP1  
	+ ASP.NET MVC 3  
	+ Facebook C# SDK
	+ Twitter Bootstrap
+ Windows Azure SDK for .NET 1.6

#### 利用方法 ####
1. .\OpenGraphSample-After\OpenGraphWeb フォルダにある Web.config ファイルの  
FacebookAppId と FacebookAppNamespace の Value に自身のFacebookアプリのAppId,  
AppNamespaceをそれぞれ設定します。

2. Windows AzureプロジェクトのOpenGraphSampleにてWindows Azure用サービスパッケージを  
生成し、Windows Azure上のホストサービスにデプロイします。

ライセンス
----
The MIT License¶

Copyright (c) 2012 Keiji Kamebuchi

以下に定める条件に従い、本ソフトウェアおよび関連文書のファイル（以下「ソフトウェア」）の複製を取得するすべての人に対し、ソフトウェアを無制限に扱うことを無償で許可します。これには、ソフトウェアの複製を使用、複写、変更、結合、掲載、頒布、サブライセンス、および/または販売する権利、およびソフトウェアを提供する相手に同じことを許可する権利も無制限に含まれます。

上記の著作権表示および本許諾表示を、ソフトウェアのすべての複製または重要な部分に記載するものとします。

ソフトウェアは「現状のまま」で、明示であるか暗黙であるかを問わず、何らの保証もなく提供されます。ここでいう保証とは、商品性、特定の目的への適合性、および権利非侵害についての保証も含みますが、それに限定されるものではありません。 作者または著作権者は、契約行為、不法行為、またはそれ以外であろうと、ソフトウェアに起因または関連し、あるいはソフトウェアの使用またはその他の扱いによって生じる一切の請求、損害、その他の義務について何らの責任も負わないものとします。

