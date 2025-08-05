# 🛠️ EntityFileGenerator Tool

**EntityFileGenerator** is a utility designed to automate the creation of **Entity**, **Interface**, and **EfEntity** files in .NET projects. It's especially useful for projects utilizing **Entity Framework** and the **Repository Pattern**, helping developers quickly generate the foundational files required for each entity class.

---

## ✨ Features

- **Entity File Creation**: Generates an entity class that maps to a corresponding database table.
- **Interface Layer**: Creates the DAL (Data Access Layer) interface for each entity.
- **EfEntity Layer**: Implements the data access logic using Entity Framework.
- **Directory-Based Processing**: Reads all files from a specified directory and generates the corresponding entity, interface, and EF files quickly.

---

## 🚀 Usage

### Integrate into Project

This tool can be included in your .NET project. You can manage operations through functions like `EntityLayer`, `InterfaceLayer`, and `EfLayer`.

### File Generation

- Uses `Directory.GetFiles()` to read files from the specified directory.
- For each file, it generates the corresponding **Entity**, **Interface**, and **EfEntity** class.
- Files are saved by default into the following folders:
  - `Entities/Concrete`
  - `DataAccess/Abstract`
  - `DataAccess/Concrete/EntityFramework`

### Code Templates

File contents are generated using pre-defined format strings that define the structure of each file (Entity, Interface, and EF Repository).

### Customization

The format strings for templates can be customized and extended as needed.

---

## 📚 User Guide

- Use the `CreateFiles` function to scan an existing directory and generate all required files.
- Use `EntityLayer`, `InterfaceLayer`, and `EfLayer` individually to generate each component separately.
- The tool includes safety checks to prevent overwriting or re-processing already existing files.

---

## 📋 Requirements

- **.NET Framework**: Designed for use within .NET-based projects.
- **Entity Framework Core**: Required for database operations and EF integration.

---

## 🤝 Contribution

Contributions are welcome! You can:
- Open a **pull request**
- Solve existing **issues**
- Submit suggestions or bug reports via the **Issues** tab

---
