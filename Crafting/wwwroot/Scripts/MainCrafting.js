// get recipe ID from select box, (active-recipe)
// get recipe quantities from database
// get inventory quantities from database
// check to see if inventory quantities are greater than recipe

$("#active-recipe").on("change", () => {
  let targetRecipe = $("#active-recipe option:selected").val();
  $("#recipe-details").load(`/LoadRecipe/${targetRecipe}`);
});