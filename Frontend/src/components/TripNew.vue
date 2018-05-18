<template>
  <div>
    <h1>Ajout d'un nouveau trajet</h1>

    <el-form ref="form" :model="form" label-width="200px" label-position="left" style="width: 80%;margin-left:10%;">
      <el-form-item label="Départ">
        <el-input v-model="form.departure_city" placeholder=""></el-input>
      </el-form-item>

      <el-form-item label="Arrivée">
        <el-input v-model="form.arriving_city" placeholder=""></el-input>
      </el-form-item>

      <el-form-item label="Date de départ">
        <el-date-picker type="datetime" placeholder="Date" v-model="form.departure_time" style="width: 100%;"></el-date-picker>
      </el-form-item>

      <el-form-item label="Date d'arrivée">
        <el-date-picker type="datetime" placeholder="Date" v-model="form.arriving_time" style="width: 100%;"></el-date-picker>
      </el-form-item>

      <el-form-item label="Prix par personne (€)">
        <el-input-number v-model="form.price" style="width: 100%" placeholder="Prix"></el-input-number>
      </el-form-item>

      <el-form-item label="Nombre de places disponibles">
        <el-input-number v-model="form.remaining_seats" style="width: 100%" placeholder="Places disponibles"></el-input-number>
      </el-form-item>

      <el-form-item label="Véhicule">
        <el-select  v-model="form.car_id" clearable placeholder="Véhicule utilisé"  style="width: 100%">
          <el-option
            v-for="item in cars"
            :key="item.id"
            :label="item.model"
            :value="item.id">
            <span style="float: left">{{ item.model }}</span>
            <span style="float: right; text-transform: capitalize;">{{ item.color }}</span>
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item>
        <el-row type="flex" justify="space-between" style="margin-top: 30px;">
          <el-button @click="$router.push('/home')">Annuler</el-button>
          <el-button type="primary" @click="addTrip">Ajouter</el-button>
        </el-row>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
  export default
  {
    name: "TripAdd",
    data()
    {
      return {
        cars:
        [
          {
            id: "1",
            model: "Opel Astra",
            color: "rouge",
            registration: "XXX"
          },
          {
            id: "2",
            model: "Porsche 911 GTS2",
            color: "noire"
          }
        ],
        form:
        {
          departure_city: "",
          arriving_city: "",
          departure_time: "",
          arriving_time: "",
          car_id: null,
          user_id: null

        }
      }
    },
    methods:
    {
      addTrip()
      {
        this.$http.defaults.headers.common['Authorization'] = "Bearer "+  this.$session.get("token");

        this.$http.request(
          {
            url: "/trips",
            method: "post",
            data: this.form
          })
        .then(res =>
        {
          this.$router.push("/trips/"+res.data.id);
        })
        .catch(err =>
        {

        });
      }
    },
    mounted()
    {
      this.$http.get('/users/'+this.$session.get('id')+"/cars")
      .then(res =>
      {
        this.cars = res.data
      })
      .catch(err =>
      {

      });

      this.form.user_id = this.$session.get('id');

    }
  }
</script>

<style scoped>

</style>