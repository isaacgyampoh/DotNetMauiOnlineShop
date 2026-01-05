# DotNetMauiOnlineShop

A cross-platform online shopping application built with **.NET MAUI** and the **CommunityToolkit.Mvvm**. This app demonstrates a modern mobile architecture using the MVVM pattern, Dependency Injection, and platform-specific UI rendering.

## Features

- **Product Browsing**: View a list of available products with images and prices.
- **Shopping Cart**: Add items to cart, view totals, and manage quantities.
- **Checkout**: Simple checkout flow to capture shipping information.
- **Order Tracking**: View order history and status.
- **Cross-Platform**: Runs on Android, iOS, macOS, and Windows (currently optimized for Android).

## Technology Stack

- **Framework**: .NET MAUI (.NET 9)
- **Architecture**: MVVM (Model-View-ViewModel)
- **MVVM Library**: CommunityToolkit.Mvvm
- **Language**: C# 12
- **IDE**: VS Code / Visual Studio

## Prerequisites

- **.NET 9 SDK**: [Download here](https://dotnet.microsoft.com/download/dotnet/9.0)
- **Android SDK**: Required for Android development.
- **MAUI Workload**: `dotnet workload install maui-android`

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/isaacgyampoh/DotNetMauiOnlineShop.git
cd DotNetMauiOnlineShop
```

### 2. Setup Environment Variables (Linux/macOS)

Ensure your Android SDK path is set correctly:

```bash
export ANDROID_HOME=~/.android-sdk
export ANDROID_SDK_ROOT=~/.android-sdk
```

### 3. Build and Run

To run on an Android emulator or device:

```bash
dotnet build -t:Run -f net9.0-android
```

## Architecture

The project follows a clean **MVVM** architecture:

- **Models**: Plain C# objects representing data (`Product`, `CartItem`, `Order`).
- **ViewModels**: Handle business logic and state (`ProductsViewModel`, `CartViewModel`). Inherit from `ObservableObject`.
- **Views**: XAML pages with code-behind for UI logic (`ProductsPage`, `CartPage`).
- **Services**: `ApiService` handles data fetching (currently using mock data).

## Project Structure

```
DotNetMauiOnlineShop/
├── Models/          # Data models
├── ViewModels/      # ViewModels (MVVM)
├── Views/           # UI Pages (XAML)
├── Services/        # Data services
├── Resources/       # Images, Fonts, Styles
├── MauiProgram.cs   # Dependency Injection setup
└── AppShell.xaml    # Navigation routing
```

## License

MIT