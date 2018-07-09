#!/usr/bin/env bash
cd ..
dotnet restore ./WorldData
dotnet build ./WorldData
dotnet restore ./WorldData.Tests/
