<template>
  <v-app id="inspire">
    <!--Top Page Element-->
    <v-app-bar app fluid color="primary lighten-1">
      <v-container class="py-0 fill-height white--text">
        <v-spacer></v-spacer>
        <b> Consulta de Alunos </b>
        <v-spacer></v-spacer>

        <v-btn elevation="2" rounded color="blue" class="white--text"
          >Cadastrar Aluno</v-btn
        >

        <v-responsive max-width="300">
          <v-text-field
            dense
            flat
            hide-details
            rounded
            solo-inverted
            append-icon="mdi-magnify"
            label="Pesquisar"
          >
          </v-text-field>
        </v-responsive>
      </v-container>
    </v-app-bar>
    <!--Top Page Element-->

    <!--Side Page Element-->
    <v-navigation-drawer app absolute permanent width="320px">
      <v-card height="64px">
        <v-card-title flat class="black--text">Módulo do Acadêmico</v-card-title>
      </v-card>
    </v-navigation-drawer>

    <!--Side Page Element-->

    <!--Main Page Element-->
    <v-main class="grey lighten-3">
      <v-container>
        <router-view></router-view>
        <v-data-table :headers="headers" :items="items" class="elevation-1">
          <template slot="item.delete">
            <v-row align="center" justify="space-around">
              <v-col>
                <v-btn tile color="error">
                  <v-icon left> mdi-delete </v-icon>
                  Deletar
                </v-btn>
              </v-col>
            </v-row>
          </template>
          <template slot="item.edit">
            <v-row align="center" justify="space-around">
              <v-col>
                <v-btn tile color="success">
                  <v-icon left> mdi-pencil </v-icon>
                  Editar
                </v-btn>
              </v-col>
            </v-row>
          </template>
        </v-data-table>
      </v-container>
    </v-main>
    <!--Main Page Element-->

    <!--Bottom Page Element-->
    <v-footer color="primary lighten-1" padless>
      <v-row justify="center" no-gutters>
        <v-btn v-for="link in links" :key="link" color="white" text rounded class="my-2">
          {{ link }}
        </v-btn>
        <v-col class="primary lighten-2 py-4 text-center white--text" cols="12">
          {{ new Date().getFullYear() }} — <strong>made by Caiã</strong>
        </v-col>
      </v-row>
    </v-footer>
    <!--Bottom Page Element-->
  </v-app>
</template>

<script>
export default {
  data() {
    return {
      headers: [
        {
          text: "Registro Acadêmico",
          value: "ra",
          align: "center",
          filterable: true,
        },
        {
          text: "Name",
          value: "name",
          align: "center",
          filterable: true,
        },
        {
          text: "CPF",
          value: "cpf",
          align: "center",
          filterable: true,
        },
        {
          text: "",
          value: "edit",
          align: "right",
          filterable: false,
        },
        {
          text: "",
          value: "delete",
          align: "left",
          filterable: false,
        },
      ],
      items: [
        {
          id: 1,
          ra: "0000000001",
          name: "Caia",
          cpf: "03688094042",
        },
        {
          id: 2,
          ra: "0000000002",
          name: "Marcela",
          cpf: "03425293079",
        },
      ],
    };
  },
  methods: {
    delete(item) {
      this.items = this.items.filter((d) => d.id !== item.id);
    },
    edit(item) {
      this.items = this.items.filter((e) => e.id !== item.id);
    },
  },
};
</script>
