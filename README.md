
# 🧾 Receipt Reimbursement App

This is a full-stack web application that allows university employees to submit receipts for reimbursement. The app provides a simple form to upload receipts, stores them in the backend, and displays all submissions in a table.

---

## 📌 Features

- Submit purchase receipts with:
  - Date
  - Amount
  - Description
  - File Upload (PDF/Image/DOCX/etc.)
- View all submitted receipts
- Drag-and-drop file upload
- Backend file storage
- SQL Server database persistence

---

## ⚙️ Tech Stack

| Frontend        | Backend         | Database        |
|----------------|------------------|-----------------|
| React (Create React App) | ASP.NET Core Web API | SQL Server |

---

## 🚀 Getting Started

### Prerequisites

- Node.js & npm
- .NET 7 SDK or later
- SQL Server (local or cloud)
- Visual Studio or VS Code

---

### 🔧 Backend Setup

1. Navigate to the backend folder:

   ```bash
   cd ReceiptReimbursementAPI
   ```

2. Update the connection string in `appsettings.json`:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=ReceiptDB;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

3. Run migrations (if not already done):

   ```bash
   dotnet ef database update
   ```

4. Run the API:

   ```bash
   dotnet run
   ```

---

### 💻 Frontend Setup

1. Navigate to the frontend folder:

   ```bash
   cd myapp
   ```

2. Install dependencies:

   ```bash
   npm install
   ```

3. Run the app:

   ```bash
   npm start
   ```

4. Open your browser:

   ```
   http://localhost:3000 (or 3001/3002)
   ```

---

## 🌐 API Endpoints

| Method | Endpoint                    | Description                    |
|--------|-----------------------------|--------------------------------|
| POST   | `/api/receipt/submit`       | Submit a new receipt           |
| GET    | `/api/receipt/all`          | Retrieve all submitted receipts |

---

## 📝 Assumptions & Notes

- Files are stored in the server's `wwwroot/uploads` folder.
- Only basic validation is applied on client and server.
- CORS is enabled for development on ports `3000`, `3001`, and `3002`.

---

## 🕓 Time Tracking

| Phase         | Estimated | Actual |
|---------------|-----------|--------|
| Backend Setup | 3 hours   | 2.5 hrs|
| Frontend Dev  | 3 hours   | 3 hrs  |
| Testing & Fixes | 2 hours | 1.5 hrs|

---

## 📁 Folder Structure

```
📁 ReceiptReimbursementAPI
  └── Controllers
  └── Models
  └── Services
  └── DTOs
  └── Data
📁 myapp
  └── src
      └── Home.js
      └── App.js
      └── App.css
```

---

## ✍️ Author

**Your Name**  
Email: your.email@example.com  
GitHub: [yourusername](https://github.com/yourusername)
