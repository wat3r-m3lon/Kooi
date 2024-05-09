<template>
  <div>
    <div class="search-box">
      <v-sheet width="300" class="mx-auto">
        <v-form @submit.prevent>
          <v-text-field
            v-model="selectData.id"
            label="Tooltip content"
          ></v-text-field>
          <v-btn type="submit" block class="mt-2" @click="onSubmit"
            >Search</v-btn
          >
        </v-form>
      </v-sheet>
    </div>

    <v-data-table
      :headers="headers"
      :items="list"
      item-key="Title"
      class="elevation-1"
    >
      <template v-slot:item.actions="{ item }">
        <v-icon size="small" class="me-2" @click="showTooltip(item)">
          mdi-pencil
        </v-icon>
      </template>
    </v-data-table>
  </div>

  <v-row justify="center">
    <v-dialog v-model="show" persistent width="1024">
      <v-card :model="current">
        <v-card-title>
          <span class="text-h5">Edit Tooltip</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row :model="current">
              <v-col cols="12">
                <v-text-field
                  label="Title"
                  required
                  v-model="current.title"
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="4">
                <v-select
                  :items="['Question Mark']"
                  label="Icon"
                  required
                  v-model="current.iconId"
                ></v-select>
              </v-col>
              <v-col cols="12" sm="4">
                <v-select
                  :items="['center', 'end', 'start']"
                  label="IconAlign"
                  required
                  v-model="current.iconAlignId"
                ></v-select>
              </v-col>
              <v-col cols="12" sm="4">
                <v-select
                  item-text="sideName"
                  item-value="sideId"
                  :items="sideList"
                  label="IconSide"
                  required
                  v-model="current.iconSideId"
                ></v-select>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue-darken-1" variant="text" @click="show = false">
            Change a Target Object
          </v-btn>
          <v-btn color="blue-darken-1" variant="text" @click="show = false">
            Close
          </v-btn>
          <v-btn color="blue-darken-1" variant="text" @click="updateTooltip">
            Save
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>


<script lang="ts">
import { onMounted, watch } from "vue";
import { defineComponent, reactive, toRefs } from "vue";
import {
  getTooltipsList,
  getAlignmentsList,
  getSidesList,
} from "../request/api";
import { updateTooltipById } from "../request/api";
import { InitData, ListInt } from "../type/tooltips";
import type { ReadonlyDataTableHeader } from "@/models/components/DataTableHeaders";

export default defineComponent({
  setup() {
    const data = reactive(new InitData());

    onMounted(() => {
      getTooltips();
      getSides();
      getAlignments();
    });
    const getTooltips = () => {
      getTooltipsList().then((res) => {
        data.list = res.data.data;
      });
    };
    const getSides = () => {
      getSidesList().then((res) => {
        data.sideList = res.data.data;
      });
    };
    const getAlignments = () => {
      getAlignmentsList().then((res) => {
        data.alignList = res.data.data;
      });
    };
    const onSubmit = () => {
      let arr: ListInt[] = [];
      if (data.selectData.id) {
        arr = data.list.filter((value) => {
          return value.title.indexOf(data.selectData.id) !== -1;
        });
      } else {
        arr = data.list;
      }
      data.list = arr;
    };

    const showTooltip = (row: ListInt) => {
      data.current = JSON.parse(JSON.stringify(row));
      data.show = true;
    };

    const updateTooltip = () => {
      updateTooltipById(data.current.id, data.current);
      data.reload = true;
      data.show = false;
    };

    const headers: Array<ReadonlyDataTableHeader> = [
      {
        title: "Text Content",
        align: "start",
        sortable: true,
        key: "title",
      },
      {
        title: "Tooltip Id",
        align: "start",
        sortable: true,
        key: "id",
      },
      {
        title: "Target web object",
        align: "start",
        sortable: true,
        key: "elementIdentifier",
      },
      {
        title: "Date",
        align: "start",
        sortable: true,
        key: "reportCount",
      },
      {
        title: "Edit",
        align: "end",
        sortable: false,
        key: "actions",
      },
    ];

    watch([() => data.selectData.id, () => data.reload], () => {
      if (data.selectData.id == "") {
        getTooltips();
      }
      if (data.reload == true) {
        getTooltips();
      }
    });

    return {
      ...toRefs(data),
      onSubmit,
      showTooltip,
      updateTooltip,
      headers,
    };
  },
});
</script>

<style>
.search-box {
  margin-bottom: 20px;
}
</style>
