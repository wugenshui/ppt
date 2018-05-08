new Vue({
  el: "#app",
  data: {
    newItem: "",
    items: [
      { desc: "学习Vue官网教程", type: 1 },
      { desc: "编写Vue小Demo", type: 1 },
      { desc: "阅读Vue相关资料", type: 0 },
      { desc: "完成一个小型的项目", type: 0 }
    ]
  },
  methods: {
    addItem: function() {
      if (this.newItem.length > 0) {
        this.items.push({ desc: this.newItem, type: 0 })
        this.newItem = ""
      } else {
        alert("待办任务不能为空!")
      }
    },
    toggleType: function(item) {
      if (item.type == 0) {
        item.type = 1
      } else {
        item.type = 0
      }
    },
    delItem: function(index) {
      this.items.splice(index, 1)
    }
  },
  computed: {
    todoCount: function() {
      // 待办任务数量
      return this.items.filter(function(item) {
        return item.type == 0
      }).length
    },
    finishCount: function() {
      // 已完成任务数量
      return this.items.filter(function(item) {
        return item.type != 0
      }).length
    }
  }
})
