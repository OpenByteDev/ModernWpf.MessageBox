# ModernWpf.MessageBox

![nuget badge](https://badgen.net/nuget/v/modernwpf.messagebox)
[![Unlicense](https://img.shields.io/github/license/OpenByteDev/ModernWpf.MessageBox)](./LICENSE)

A drop-in replacement for `System.Windows.MessageBox` (and `System.Windows.Forms.MessageBox`) built using a [Modern WPF UI](https://github.com/Kinnara/ModernWpf).

## Installation

To install with NuGet use the following command in the Packet Manager Console:
```
Install-Package ModernWpf.MessageBox
```

## Usage
A simple usage example:
```cs
MessageBox.Show("This is a test text!", "Some title", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
```
**ModernWPF.MessageBox**

![ModernWpf.MessageBox](https://raw.githubusercontent.com/OpenByteDev/ModernWpf.MessageBox/master/screenshots/Screenshot-01.png) 

**System.Windows.MessageBox**

![System.WindowsMessageBox](https://raw.githubusercontent.com/OpenByteDev/ModernWpf.MessageBox/master/screenshots/Screenshot-02.png)
