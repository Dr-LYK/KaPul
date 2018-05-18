<template>
  <div>
    <h2 style="line-height: 50px;">Où allez vous ?</h2>
    <el-form ref="form" :model="form" label-width="0">
      <el-form-item label="">
        <el-col :span="4">
          <i class="fab fa-font-awesome-flag"></i>
        </el-col>
        <el-col :span="16">
          <el-input v-model="form.departure_city" placeholder="Départ"></el-input>
        </el-col>
      </el-form-item>
      <el-form-item label="">
        <el-col :span="4">
          <i class="fab fa-font-awesome-flag"></i>
        </el-col>
        <el-col :span="16">
          <el-input v-model="form.arriving_city" placeholder="Destination"></el-input>
        </el-col>
      </el-form-item>
      <el-form-item >
        <el-col :span="4">
          <i class="far fa-calendar-alt"></i>
        </el-col>
        <el-col :span="16">
          <el-date-picker prefix-icon="" type="datetime" placeholder="Date" v-model="form.departure_time" style="width: 100%;"></el-date-picker>
        </el-col>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="searchTrip">J'y vais !</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
  export default
  {
    name: "TripSearch",
    data()
    {
      return {
      }
    },
    props: ['form'],

    methods:
    {
      searchTrip: function()
      {

        this.$router.push('/trips?from='+this.form.from+'&to='+this.form.to+'&date='+this.form.date);
      }
    }

  }
</script>

<style scoped>
  i
  {
    font-size: x-large;
    text-align: center;
  }

</style>