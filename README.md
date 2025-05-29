![image](https://github.com/user-attachments/assets/d532d033-88ea-4ea7-9861-0b048c58416a)
# Sheetify
## Description
Sheetify is a desktop-based sheet music management system developed with C# and .NET. It functions as a comprehensive platform for musicians to buy, sell, organize, and digitize sheet music, both in PDF and image formats. This application aims to centralize all music score-related tasks in a single intuitive environment.

## Details

Sheetify includes multiple integrated modules and technologies:

- **Score Management**: Users can upload PDF or image-based sheet music. Through the integration of [Audiveris](https://github.com/Audiveris/audiveris), the app digitizes physical scores using Optical Music Recognition (OMR).
- **Secure Authentication**: Passwords are securely encrypted using `BCrypt.Net` before being stored in the database.
- **License System**: Scores can be shared under free or paid licenses. Paid licenses include time-limited access and download permissions.
- **Store and Cart System**: Users can browse and purchase scores, track their orders, and receive receipts in PDF format.
- **Admin Tools**: Administrators can approve uploads, manage users, licenses, sales, and monitor platform-wide activity.

## Why Sheetify

While existing music software platforms focus on either performance or editing, few provide a full offline management solution with features such as:

- Optical Music Recognition for physical score conversion.
- Offline score organization with metadata-based filters.
- License-restricted content distribution and PDF rendering.
- Secure and personalized user accounts with purchase history.
- Educator- and student-friendly workflow for classroom or professional use.

## Technology Stack

- **Language**: C#
- **Framework**: .NET Framework (WinForms)
- **OCR Engine**: [Audiveris](https://github.com/Audiveris/audiveris)
- **PDF Tools**: PDFsharp, MigraDoc, PdfiumViewer
- **Database**: SQL Server
- **Authentication**: [BCrypt.Net](https://github.com/BcryptNet/bcrypt.net)

Sheetify was developed to fill that gap, offering an extensible and modular system that can scale from individual musicians to institutions.
