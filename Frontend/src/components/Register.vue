<template>
  <div>
    <el-form style="margin-top: 100px;width: 80%;margin-left: 10%;" label-position="right" :model="form">
      <el-form-item label="Nom">
        <el-input v-model="form.name"></el-input>
      </el-form-item>
      <el-form-item label="Prénom">
        <el-input v-model="form.firstname"></el-input>
      </el-form-item>
      <el-form-item label="Email">
        <el-input v-model="form.email"></el-input>
      </el-form-item>
      <el-form-item label="Mot de passe">
        <el-input type="password" v-model="form.password"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="register()">S'inscrire</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
  export default
  {
    name: "Register",
    data()
    {
      return {
        form:
        {
          name: "",
          firstname: "",
          email: "",
          password: ""
        },
        httpErr: ""
      }
    },
    methods:
    {
      register()
      {
        this.$http.request(
        {
          url: "/users/register",
          method: "post",
          data: this.form
        })
        .then(res =>
        {
          this.httpErr =  "Votre inscription a été prise en compte";
          this.$router.push("/home");

        })
        .catch(err =>
        {
          //console.log(err)
          if (err.response.status === "400")
            this.httpErr = "Champs invalides";
        });
      }
    }

  }
</script>

<style scoped>

</style>