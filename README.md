# Currency Converter for PowerToys Run
![Build Pipeline](https://github.com/nathancartlidge/powertoys-run-currency/actions/workflows/build.yml/badge.svg)

## Introduction
**TLDR:** this plugin lets you type `100 GBP to USD` and get the live price

This plugin is powered by [Frankfurter](https://www.frankfurter.app/), an open source API for exchange rates

## Installation
### Automatic Installation (`winget`)
*This doesn't work yet, sorry!*

### Manual Installation
1. Go to the [latest release](https://github.com/nathancartlidge/powertoys-run-unicode/releases/latest) and download the
   `.zip` file that matches your architecture - this is probably `x64` if you are unsure.
2. Close PowerToys
3. Locate your plugin installation folder: for me, this was `~\AppData\Local\Microsoft\PowerToys\PowerToys Run\Plugins`
4. Copy the plugin folder (`CurrencyConverter`) from the release into this folder (such that the path
   `...\PowerToys Run\Plugins\CurrencyConverter\` exists)
5. Open PowerToys and enable the plugin!
6. 🥳

## Development / Contributing
- This project is based upon dotnet version 8.0.x - to work on it, you will likely want a similar configuration.
- You may wish to update the libraries in `src/libs` with copies from your own machine - these can be found in the root
  directory of your PowerToys installation.
- Please write unit tests for any functionality you add

## Attribution
- Initial project structure based upon [ptrun-guid](https://github.com/skttl/ptrun-guid) by `skttl`
- GitHub CI pipeline based upon [PowerToys Run: GitKraken](https://github.com/davidegiacometti/PowerToys-Run-GitKraken) 
  by `davidegiacometti`
