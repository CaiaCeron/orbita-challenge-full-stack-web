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
      <template v-slot:[`item.actions`]="{ item }">
        <div class="text-truncate">
          <v-btn text small @click="editItem(item), (dialogEdit = true)">
            <v-icon class="mr-2" color="primary"> mdi-pencil </v-icon>
          </v-btn>
          <v-btn text small @click="deleteItem(item)">
            <v-icon class="mr-2" color="pink"> mdi-delete </v-icon>
          </v-btn>
        </div>
      </template>
    </v-data-table>
    <!--TABELA-->

    <!--MODAL DE EDIÇÃO DE ALUNO-->
    <v-dialog v-model="dialogEdit" persistent max-width="600px">
      <v-card>
        <v-card-title>
          <span class="text-h5">Editar Aluno</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-text-field v-model="studentEdit.id"></v-text-field>

              <v-col cols="12">
                <v-text-field
                  v-model="studentEdit.name"
                  label="Nome"
                  required
                  rounded
                  filled
                  dense
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field
                  v-model="studentEdit.email"
                  label="E-mail"
                  required
                  rounded
                  filled
                  dense
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field
                  v-model="studentEdit.ra"
                  label="Registro Acadêmico"
                  rounded
                  filled
                  dense
                  disabled
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field
                  v-model="studentEdit.cpf"
                  label="CPF"
                  rounded
                  filled
                  dense
                  disabled
                ></v-text-field>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="error" text @click="dialogEdit = false"> Close </v-btn>
          <v-btn color="success" text @click="(dialogEdit = false), alterateItem()">
            Save
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <!--MODAL DE EDIÇÃO DE ALUNO-->

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
  title() {
    return `CRUD - ${this.someValue}`;
  },

  data() {
    return {
      someValue: "Cadastro de Alunos",
      dialogDelete: false,
      dialogEdit: false,
      search: "",
      headers: [
        { text: "Registro Acadêmico", value: "ra", align: "center", sortable: true },

        { text: "Nome", value: "name", align: "center" },

        { text: "CPF", value: "cpf", align: "center" },

        { text: "e-mail", value: "email", align: "center" },

        { text: "Ações", value: "actions", align: "center", sortable: false },
      ],
      students: [],
      studentEdit: {
        cpf: "",
        email: "",
        id: "",
        name: "",
        ra: "",
      },
      errors: [],
    };
  },

  watch: {
    dialogDelete(val) {
      val || this.closeDelete();
    },
  },

  methods: {
    refreshList() {
      api.get("/api/Student/").then((res) => {
        this.students = res.data;
      });
    },

    editItem(student) {
      this.studentEdit = student;
      console.log(this.studentEdit);
    },

    alterateItem() {
      console.log(this.studentEdit);
      api.put("/api/Student/" + this.studentEdit.id, this.studentEdit).then((resp) => {
        console.log(resp);
        this.refreshList();
      });
    },

    deleteItem(student) {
      this.index = student.id;
      this.dialogDelete = true;
    },

    deleteItemConfirm() {
      api.delete("/api/Student/" + this.index).then(() => {
        this.refreshList();
        this.closeDelete();
      });
    },
    closeDelete() {
      this.dialogDelete = false;
    },
  },

  created() {
    this.refreshList();
  },

  mounted() {
    Student.List().then((received) => {
      this.students = received.data;
    });
  },
};
</script>
