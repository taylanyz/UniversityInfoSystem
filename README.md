# 🎓 University Information System – RESTful API

## 📌 Project Overview

This project is a simple implementation of a **University Information System** developed as part of our Web Server Programming homework. The system is built using a RESTful API structure, allowing basic interaction between key entities such as **Students**, **Courses**, and **Classrooms** using standard HTTP methods.

> ⚙️ This homework focuses on practicing REST principles through a minimal but functional API.

---

## 🧩 Entities and Endpoints

The API provides CRUD operations (Create, Read, Update, Delete) for the following components:

### 👨‍🎓 Students
- `GET /api/students` — Get all students
- `GET /api/students/{id}` — Get one student
- `POST /api/students` — Add a new student
- `PUT /api/students/{id}` — Update a student
- `DELETE /api/students/{id}` — Delete a student

### 📚 Courses
- `GET /api/courses`
- `POST /api/courses`
- etc.

### 🏫 Classrooms
- `GET /api/classrooms`
- `GET /api/classrooms/{id}`

---

## 🧪 Sample Operation

For example, adding a student is done with a simple `POST` request:

```json
POST /api/courses

{
    "id": "BIM308",
    "title": "Web Server Programming",
    "classroom": "B6"
}
