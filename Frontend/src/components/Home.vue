<template>
  <div class="home">
    <el-row :gutter="10" type="flex" justify="space-around">

      <el-col :span="7">
        <h2>Nos meilleurs tarifs</h2>

        <el-row :gutter="20" type="flex" justify="space-around">
          <el-col :span="6" class="bg-grey"></el-col>
          <el-col :span="6" class="bg-grey"></el-col>
          <el-col :span="6" class="bg-grey"></el-col>
        </el-row>
      </el-col>

      <el-col :span="3">
        <h2>Où allez vous ?</h2>
        <el-form ref="form" :model="form" label-width="120px">
          <el-form-item label="Départ">
            <el-input v-model="form.from"></el-input>
          </el-form-item>
          <el-form-item label="Arrivée">
            <el-input v-model="form.to"></el-input>
          </el-form-item>
          <el-form-item label="Date de départ">
            <el-col :span="11">
              <el-date-picker type="datetime" placeholder="Pick a date" v-model="form.date" style="width: 100%;"></el-date-picker>
            </el-col>
          </el-form-item>
          <el-form-item>
            <el-button type="primary" @click="onSubmit">Create</el-button>
            <el-button>Cancel</el-button>
          </el-form-item>
        </el-form>
      </el-col>

    </el-row>
    <h1>HOME</h1>
    <el-button type="info">Primary</el-button>
  </div>
</template>

<script>
  export default
  {
    name: "Home",
    data()
    {
      return {
        arrBestPrices: [],
        arrNextDepartures: []
      }
    },
    methods:
    {

    }
  }
</script>

<style scoped>

</style>