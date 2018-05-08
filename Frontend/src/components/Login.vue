<template>
  <div style="margin-top: 100px;width: 80%;margin-left: 10%;">
    <el-form label-position="right" label-width="100px" :model="form">
      <el-form-item label="Email">
        <el-input v-model="form.email"></el-input>
      </el-form-item>
      <el-form-item label="Mot de passe">
        <el-input v-model="form.password"></el-input>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="login()">Se connecter</el-button>
      </el-form-item>
    </el-form>
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
        }
      }
    },
    methods:
    {
      login()
      {
        console.log(this.form.email);
      }
    }
  }
</script>

<style scoped>

</style>