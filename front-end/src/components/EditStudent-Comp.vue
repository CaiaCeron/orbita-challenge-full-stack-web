<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" persistent max-width="600px">
      <v-card>
        <v-card-title>
          <span class="text-h5">Editar Aluno</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12">
                <v-text-field
                  v-model="name"
                  label="Nome"
                  required
                  rounded
                  filled
                  dense
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field
                  v-model="email"
                  label="E-mail"
                  required
                  rounded
                  filled
                  dense
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field
                  v-model="ra"
                  label="Registro Acadêmico"
                  rounded
                  filled
                  dense
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field
                  v-model="cpf"
                  label="CPF"
                  rounded
                  filled
                  dense
                ></v-text-field>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="dialogEdit = false"> Close </v-btn>
          <v-btn color="blue darken-1" text @click="dialogEdit = false"> Save </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>
