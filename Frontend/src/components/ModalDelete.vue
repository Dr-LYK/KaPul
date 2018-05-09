<template>
  <el-dialog
    title="Attention"
    :visible.sync="dialogVisible"
    width="30%"
    center
    :before-close="beforeClose">
    <span>{{dialogText}}</span>

    <span slot="footer" class="dialog-footer">
      <el-button @click="$emit('clickBtn', 'N', section)">Fermer</el-button>
      <el-button type="primary" @click="$emit('clickBtn', 'Y', section)">Oui</el-button>
    </span>
  </el-dialog>
</template>

<script>
  export default
  {
    name: "ModalDelete",
    props: ["dialogVisible", "dialogText", "section"],
    methods:
    {
      beforeClose()
      {
        this.$emit('clickBtn', 'N', this.section)
      }
    }

  }
</script>

<style scoped>

</style>