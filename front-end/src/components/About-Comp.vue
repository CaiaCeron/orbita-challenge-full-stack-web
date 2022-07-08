<template>
  <v-container>
    <v-row class="text-center">
      <v-col cols="12">
        <v-img :src="require('../assets/logo.svg')" class="my-3" contain height="200" />
      </v-col>

      <v-col class="mb-4">
        <h1 class="display-2 font-weight-bold mb-3">Teste CRUD</h1>
      </v-col>

      <v-col class="mb-5" cols="12">
        <h2 class="headline font-weight-bold mb-3">CADASTRO DE ALUNOS</h2>
      </v-col>

      <v-col class="mb-5" cols="12">
        <h2 class="headline font-weight-bold mb-3">Created by:</h2>
      </v-col>

      <v-col class="mb-5" cols="12">
        <h2 class="headline font-weight-bold mb-3">Caiã Ceron</h2>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  title() {
    return `CRUD - ${this.someValue}`;
  },

  data: () => ({
    someValue: "Sobre",
  }),
};
</script>
