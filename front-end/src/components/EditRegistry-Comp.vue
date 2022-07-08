<template>
  <validation-observer ref="observer" v-slot="{ invalid }">
    <form @submit.prevent="submit">
      <!--Nome-->
      <validation-provider v-slot="{ errors }" name="Name" rules="required|max:50">
        <v-text-field
          v-model="name"
          :counter="50"
          :error-messages="errors"
          label="Name"
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
          v-model="email"
          :error-messages="errors"
          label="E-mail"
          required
          rounded
          filled
          dense
        ></v-text-field>
      </validation-provider>
      <!--Email-->

      <!--RA-->
      <v-text-field
        label="Registro Academico"
        rounded
        filled
        dense
        disabled
      ></v-text-field>
      <!--RA-->

      <!--CPF-->
      <v-text-field label="CPF" rounded filled dense disabled></v-text-field>
      <!--CPF-->
      <v-btn class="mr-4" type="submit" :disabled="invalid" color="success" outlined>
        Salvar
      </v-btn>
      <v-btn to="/alunos" color="error" outlined> Cancelar </v-btn>
    </form>
  </validation-observer>
</template>

<script>
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

  components: {
    ValidationProvider,
    ValidationObserver,
  },
  data: () => ({
    someValue: "Editar Cadastro do Aluno",
    name: "",
    email: "",
    ra: "",
    cpf: "",
  }),

  methods: {
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
