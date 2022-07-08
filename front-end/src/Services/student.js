import api from "./api"

export default {

    List: () => {
        return api.get("/api/Student")
    },

    Create: (student) => {
        return api.post("/api/Student", student);
    },

    Edit: (student) => {
        return api.put("/api/Student/", + student.id);
    },

    Delete: (student) => {
        return api.delete("/api/Student/" + student.id)
    },
}   