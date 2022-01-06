let count = 0;

$("#ingredient-add").on("click", () => {
  let qty = $("#qty-to-add");
  if (qty.val() == "" || qty.val() < 1) {
    alert("Must enter a quantity of one or greater.")
  } else {
    count++;
    let ingredient = $("#item-to-add option:selected");
    $("#ingredients").append(`
      <div>
      <p>${ingredient.text()} Qty: ${qty.val()}</p>
      <input type="hidden" name="I${ingredient.val()}" value="${qty.val()}" />
      <button id="delete-entry-${count}" type="button">Delete this ingredient</button>
      </div>
    `);
    attachDelete($(`#delete-entry-${count}`));
  }
});

$("#product-add").on("click", () => {
  let qty = $("#qty-to-add");
  if (qty.val() == "" || qty.val() < 1) {
    alert("Must enter a quantity of one or greater.")
  } else {
    count++;
    let product = $("#item-to-add option:selected");
    $("#products").append(`
      <div>
      <p>${product.text()} Qty: ${qty.val()}</p>
      <input type="hidden" name="P${product.val()}" value="${qty.val()}" />
      <button id="delete-entry-${count}" type="button">Delete this product</button>
      </div>
    `);
    attachDelete($(`#delete-entry-${count}`));
  }
});

$("#final-check-button").on("click", (event) => {
  event.preventDefault();
  if (!$("#recipe-name").val() == "" && !$("#products").is(':empty') && !$("#ingredients").is(':empty'))
  {
    $("#main-form").submit();
  } else {
    alert("Though nothing comes from nothing, nothing is not a something. Try adding ingredients or products. Names are important too, make sure to give your recipe a proper name.");
  }
  
})

function attachDelete(jqueryObj) {
  jqueryObj.on("click", () => {
    jqueryObj.parent().remove();
  });
}