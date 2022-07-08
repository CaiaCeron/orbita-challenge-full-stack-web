<template>
  <validation-observer ref="observer" v-slot="{ invalid }">
    <form @submit.prevent="submit">
      <!--Nome-->
      <validation-provider v-slot="{ errors }" name="Name" rules="required|max:80">
        <v-text-field
          v-model="student.name"
          :counter="80"
          :error-messages="errors"
          label="Nome"
          required
          rounded
          filled
          dense
        ></v-text-field>
      </validation-provider>
      <!--Nome-->

      <!--Email-->
      <validation-provider v-slot="{ errors }" name="Email" rules="required|email">
        <v-text-field
          v-model="student.email"
          :error-messages="errors"
          label="E-mail"
          required
          rounded
          filled
          dense
        ></v-text-field>
      </validation-provider>
      <!--Email-->

      <!--R.A-->
      <validation-provider
        v-slot="{ errors }"
        name="RA"
        :rules="{ required: true, digits: 8 }"
      >
        <v-text-field
          v-model="student.ra"
          :counter="8"
          :error-messages="errors"
          label="Registro Academico"
          required
          rounded
          filled
          dense
        ></v-text-field>
      </validation-provider>
      <!--R.A-->

      <!--CPF-->
      <validation-provider
        v-slot="{ errors }"
        name="CPF"
        :rules="{ required: true, digits: 11 }"
      >
        <v-text-field
          v-model="student.cpf"
          :counter="11"
          :error-messages="errors"
          label="CPF"
          required
          rounded
          filled
          dense
        ></v-text-field>
      </validation-provider>
      <!--CPF-->

      <v-btn
        class="mr-4"
        :disabled="invalid"
        color="success"
        outlined
        @click="saveStudent(), clear()"
      >
        Salvar
      </v-btn>
      <v-btn to="/alunos" color="error" outlined> Cancelar </v-btn
      ><v-dialog v-model="dialogSubmit" max-width="500px" persistent>
        <v-card>
          <v-card-title class="text-h8">Aluno cadastrado com sucesso!</v-card-title>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="success" text @click="closeSubmit" to="/alunos">OK</v-btn>
            <v-spacer></v-spacer>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </form>
  </validation-observer>
</template>

<script>
import Student from "@/Services/student";

import { required, digits, email, max } from "vee-validate/dist/rules";
import {
  extend,
  ValidationObserver,
  ValidationProvider,
  setInteractionMode,
} from "vee-validate";

setInteractionMode("eager");

extend("digits", {
  ...digits,
  message: "{_field_} precisa ter {length} digitos. ({_value_})",
});

extend("required", {
  ...required,
  message: "{_field_} não pode ser vazio!",
});

extend("max", {
  ...max,
  message: "{_field_} não pode ser maior que {length} characters",
});

extend("email", {
  ...email,
  message: "Email precisa ser valido!",
});

export default {
  title() {
    return `CRUD - ${this.someValue}`;
  },

  data() {
    return {
      dialogSubmit: false,
      someValue: "Cadastrar Novo Aluno",
      student: {
        name: "",
        email: "",
        ra: "",
        cpf: "",
      },
      students: [],
    };
  },

  components: {
    ValidationProvider,
    ValidationObserver,
  },

  methods: {
    saveStudent() {
      this.dialogSubmit = true;
      Student.Create(this.student).then((received) => {
        console.log(received.data);
        this.students = received.data;
        this.clear();
      });
    },

    closeSubmit() {
      this.dialogSubmit = false;
    },

    submit() {
      this.$refs.observer.validate();
    },
    clear() {
      this.name = "";
      this.email = "";
      this.ra = "";
      this.cpf = "";
      this.$refs.observer.reset();
    },
  },
};
</script>
