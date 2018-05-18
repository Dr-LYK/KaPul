<template>
  <div style="margin-top: 100px;width: 80%;margin-left: 10%;">
    <el-form label-position="right" label-width="100px" :model="form">
      <el-form-item label="Email">
        <el-input v-model="form.email"></el-input>
      </el-form-item>
      <el-form-item label="Mot de passe">
        <el-input type="password" v-model="form.password"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="login()">Se connecter</el-button>
      </el-form-item>
    </el-form>

    <p>{{httpErr}}</p>
  </div>
</template>

<script>

  export default
  {
    name: "Login",
    data()
    {
      return {
        form:
        {
          email: "",
          password: ""
        },
        httpErr : ""
      }
    },
    methods:
    {
      login()
      {
        this.$http.request(
          {
            url: "/users/login",
            method: "post",
            data: this.form
          })
        .then(res =>
        {
          const data = res.data;

          this.$http.defaults.headers.common['Authorization'] = "Bearer "+  data.token;

          this.$session.start();
          this.$session.set("name", data.user.name);
          this.$session.set("surname", data.user.surname);
          this.$session.set("id", data.user.id);
          this.$session.set("token", data.token);

          window.location.replace('/home');


        })
        .catch(err =>
        {
          if (err.status === "400")
            this.httpErr = "Email ou password incorrect";
        });
      }
    }
  }
</script>

<style scoped>

</style>