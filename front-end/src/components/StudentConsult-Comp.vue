<template>
  <v-card>
    <v-card-title class="justify-center">
      <v-spacer></v-spacer>
      <v-text-field
        v-model="search"
        append-icon="mdi-magnify"
        label="Pesquisar Aluno"
        filled
        rounded
        dense
      ></v-text-field>
      <v-spacer></v-spacer>
      <v-btn
        class="my-6"
        outlined
        color="light-green"
        :to="'/alunos/cadastro'"
        rounded
        x-large
      >
        Cadastrar Aluno <v-icon small right>mdi-plus-circle-outline</v-icon></v-btn
      >
    </v-card-title>
    <v-divider></v-divider>
    <!--TABELA-->
    <v-data-table
      :headers="headers"
      :search="search"
      :items="students"
      mobile-breakpoint="800"
      class="elevation-0"
    >
      <tr v-for="student of students" :key="student.id">
        <td>{{ student.id }}</td>
        <td>{{ student.ra }}</td>
        <td>{{ student.name }}</td>
        <td>{{ student.cpf }}</td>
        <td>{{ student.email }}</td>
      </tr>
      <template v-slot:[`item.actions`]="{ item }">
        <div class="text-truncate">
          <v-btn text small @click="editItem(item)" to="/alunos/editar">
            <v-icon class="mr-2" color="primary"> mdi-pencil </v-icon>
          </v-btn>
          <v-btn text small @click="deleteItem(item)">
            <v-icon class="mr-2" color="pink"> mdi-delete </v-icon>
          </v-btn>
        </div>
      </template>
    </v-data-table>
    <!--TABELA-->

    <!--MODAL DE AVISO DE EXCLUSÃO-->
    <v-dialog v-model="dialogDelete" max-width="500px">
      <v-card>
        <v-card-title class="text-h8"
          >Você tem certeza que deseja deletar este aluno?</v-card-title
        >
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="closeDelete">Cancel</v-btn>
          <v-btn color="blue darken-1" text @click="deleteItemConfirm">OK</v-btn>
          <v-spacer></v-spacer>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <!--MODAL DE AVISO DE EXCLUSÃO-->
  </v-card>
</template>

<script>
import Student from "@/Services/student";
import api from "@/Services/api";

export default {
  data() {
    return {
      dialogDelete: false,
      search: "",
      headers: [
        { text: "Registro Acadêmico", value: "ra", align: "center" },

        { text: "Nome", value: "name", align: "center" },

        { text: "CPF", value: "cpf", align: "center" },

        { text: "e-mail", value: "email", align: "center" },

        { text: "Ações", value: "actions", align: "center", sortable: false },
      ],
      students: [],
      errors: [],
    };
  },

  watch: {
    dialogDelete(val) {
      val || this.closeDelete();
    },
  },

  mounted() {
    Student.List().then((received) => {
      console.log(received.data);
      this.students = received.data;
    });
  },

  methods: {
    refreshList() {
      Student.List().then((received) => {
        console.log(received.data);
        this.student = received.data;
      });
    },

    editItem(student) {
      this.student = student.id;

      console.log(this.student);
    },

    deleteItem(student) {
      this.index = student.id;
      this.dialogDelete = true;
    },

    deleteItemConfirm() {
      api.delete("/api/Student/" + this.index);
      this.closeDelete();
      this.refreshList();
    },
    closeDelete() {
      this.dialogDelete = false;
    },
  },
};
</script>
