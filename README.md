# Generic Repository &amp; UOW Pattern For .NET Core 3.1

[![Build status](https://ci.appveyor.com/api/projects/status/1gum36aiadit63bk/branch/master?svg=true)](https://ci.appveyor.com/project/senvardarsemih/genericforcore/branch/master)
[![Build Status](https://travis-ci.org/senvardarsemih/generic-for-core.svg?branch=master)](https://travis-ci.org/senvardarsemih/generic-for-core)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=senvardarsemih_genericforcore&metric=alert_status)](https://sonarcloud.io/dashboard?id=senvardarsemih_genericforcore)

* simple experimental generic repository pattern demo on .net core *

* You have to setup your own connection string in appsettings.json file.
* You have to run the entity framework core migration via package manager console (In Visual Studio go to Tools -> Nuget Package Manager -> Package Manager Console then start migration with 'Update-Database' command


## K8S Support Update ##
* You can run this app in k8s environment
* You may want to use minikube or docker desktop
* First, build docker image => <b>docker build -t gfc:1.0 .</b>
* Go to tools folder => <b>cd tools</b> , then => <b>kubectl apply -f deploy.yml</b>
* Finally => <b>kubectl apply -f service.yml</b> , then go to the browser, type localhost and hit enter, you should see the application loaded. 🌞