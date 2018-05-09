<template>
  <footer class="bg-LightGrey fixed-bottom">
    <div style="height: 50px;">
      <el-row type="flex" justify="space-between" class="mt-3">
        <el-col :span="10">
          <el-row type="flex" justify="start" >
            <el-col :span="6"><div class="grid-content"><i class="fab fa-facebook-f"></i></div></el-col>
            <el-col :span="6"><div class="grid-content"><i class="fab fa-twitter"></i></div></el-col>
            <el-col :span="6"><div class="grid-content"><i class="fab fa-linkedin-in"></i></div></el-col>
          </el-row>
        </el-col>

        <el-col :span="14">
          <el-row type="flex" justify="end">
            <el-col :span="6"><a href="#">A propos de KaPul</a></el-col>
            <el-col :span="6"><a href="#">Nous contacter</a></el-col>
          </el-row>
        </el-col>
      </el-row>
    </div>
    <div style="height: 50px;">
      <el-row type="flex" justify="space-between">
        <el-col :span="9"><a href="#" style="float:left;" class="ml-4">Conditions générales & Politique de confidentialité</a></el-col>
        <el-col :span="3"><span style="float: right;" class="mr-5">© 2018 KaPul</span></el-col>
      </el-row>
    </div>
  </footer>
</template>

<script>
  export default
  {

  }
</script>

<style scoped>

  footer i
  {
    font-size: x-large;
  }

</style>